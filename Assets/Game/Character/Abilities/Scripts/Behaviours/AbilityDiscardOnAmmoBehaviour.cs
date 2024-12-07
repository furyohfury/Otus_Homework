using Atomic.Elements;
using Atomic.Entities;
using Atomic.Extensions;
using UnityEngine;

namespace Game
{
	public sealed class AbilityDiscardOnAmmoBehaviour : IEntityInit, IEntityDispose
	{
		private IEntity _character;

		public void Init(IEntity entity)
		{
			_character = entity;
			entity.OnValueAdded += OnWeaponAdded;
		}

		private void OnWeaponAdded(IEntity entity, int apiIndex, object value)
		{
			if (apiIndex != CombatAPI.Weapon)
			{
				return;
			}

			_character.GetWeapon().Value.GetAmmo().Subscribe(OnAmmoChanged);
		}

		private void OnAmmoChanged(int count)
		{
			if (count > 0)
			{
				return;
			}
			
			_character.GetAmmo().Unsubscribe(OnAmmoChanged);
			ReactiveVariable<IEntityAspect[]> activeAbilityAspects = _character.GetActiveAbilityAspects();
			foreach (var aspect in activeAbilityAspects.Value)
			{
				aspect.Discard(_character);
			}
			activeAbilityAspects.Value = null;
		}

		public void Dispose(IEntity entity)
		{
			_character.OnValueAdded -= OnWeaponAdded;

			if (_character.TryGetWeapon(out var weapon)
			    && weapon.Value.TryGetAmmo(out var ammo))
			{
				ammo.Unsubscribe(OnAmmoChanged);
			}
		}
	}
}