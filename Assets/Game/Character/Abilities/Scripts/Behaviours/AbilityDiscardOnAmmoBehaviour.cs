using Atomic.Elements;
using Atomic.Entities;
using Atomic.Extensions;
using UnityEngine;

namespace Game
{
	public sealed class AbilityDiscardOnAmmoBehaviour : IEntityInit, IEntityDispose
	{
		private IEntity _entity;

		public void Init(IEntity entity)
		{
			_entity = entity;
			entity.OnValueAdded += OnAmmoAdded;
		}

		private void OnAmmoAdded(IEntity entity, int apiIndex, object value)
		{
			if (apiIndex != CombatAPI.Ammo)
			{
				return;
			}

			if (!entity.TryGetActiveAbilityAspect(out ReactiveVariable<IEntityAspect> aspect)
			    || aspect.Value == null)
			{
				Debug.LogError($"{entity.Name} has no active ability");
				return;
			}

			entity.GetAmmo().Subscribe(OnAmmoChanged);
		}

		private void OnAmmoChanged(int count)
		{
			if (count <= 0)
			{
				_entity.GetAmmo().Unsubscribe(OnAmmoChanged);
				var activeAbilityAspect = _entity.GetActiveAbilityAspect();
				activeAbilityAspect.Value.Discard(_entity);
				activeAbilityAspect.Value = null;
			}
		}

		public void Dispose(IEntity entity)
		{
			_entity.OnValueAdded -= OnAmmoAdded;

			if (entity.TryGetAmmo(out var ammo))
			{
				ammo.Unsubscribe(OnAmmoChanged);
			}
		}
	}
}