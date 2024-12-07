using System;
using System.Collections.Generic;
using System.Linq;
using Atomic.Elements;
using Atomic.Entities;
using Atomic.Extensions;

namespace Game
{
	public sealed class AbilityInventoryBehaviour : IEntityInit, IEntityDispose
	{
		private IEntity _character;

		private ReactiveList<IEntityAspect> _activeAbilityAspects;
		private IEvent<AbilityCardConfig> _abilityCardPickupEvent;
		private List<AbilityCardState> _states;
		private BaseEvent _removeActiveAbilityEvent;
		private ReactiveList<AbilityCardState> _abilityInventory;

		public void Init(IEntity entity)
		{
			_character = entity;
			_abilityInventory = entity.GetAbilityInventory();
			_activeAbilityAspects = entity.GetActiveAbilityAspects();

			_removeActiveAbilityEvent = entity.GetRemoveActiveAbilityEvent();
			_removeActiveAbilityEvent.Subscribe(OnRemoveActiveAbility);

			_abilityCardPickupEvent = entity.GetAbilityCardPickupEvent();
			_abilityCardPickupEvent.Subscribe(OnAbilityPickUp);
		}

		private void OnAbilityPickUp(AbilityCardConfig config)
		{
			ReactiveVariable<SceneEntity> newWeapon = _character.GetWeapon();
			ReactiveVariable<int> newWeaponAmmo = newWeapon.Value.GetAmmo();
			AbilityCardState cardState = new AbilityCardState
			                             {
				                             Config = config, CurrentAmmo = newWeaponAmmo.Value
			                             };

			SubscribeStateToChanges(cardState);
			_abilityInventory.Add(cardState);
		}

		private void OnRemoveActiveAbility()
		{
			if (_abilityInventory.Count <= 0)
			{
				throw new Exception("Ability inventory didnt have removed ability");
			}

			AbilityCardState lastState = _abilityInventory.Last();
			_abilityInventory.Remove(lastState);

			if (_abilityInventory.Count > 0)
			{
				lastState = _abilityInventory.Last();

				foreach (var aspect in lastState.Config.Aspects)
				{
					aspect.Apply(_character);
				}

				var characterWeapon = _character.GetWeapon().Value;
				characterWeapon.GetAmmo().Value = lastState.CurrentAmmo;
				SubscribeStateToChanges(lastState);

				_activeAbilityAspects.Clear();
				IEntityAspect[] configAspects = lastState.Config.Aspects;
				for (int i = 0; i < configAspects.Length; i++)
				{
					_activeAbilityAspects.Add(configAspects[i]);
				}
			}
		}

		private void SubscribeStateToChanges(AbilityCardState state)
		{
			var characterWeapon = _character.GetWeapon().Value;
			ReactiveVariable<int> ammo = characterWeapon.GetAmmo();
			ammo.Subscribe(count => state.CurrentAmmo = count);
		}

		public void Dispose(IEntity entity)
		{
			_abilityCardPickupEvent.Unsubscribe(OnAbilityPickUp);
		}
	}
}