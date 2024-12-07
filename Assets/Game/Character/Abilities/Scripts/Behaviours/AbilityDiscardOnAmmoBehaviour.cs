using Atomic.Elements;
using Atomic.Entities;

namespace Game
{
	public sealed class AbilityDiscardOnAmmoBehaviour : IEntityInit, IEntityDispose
	{
		private IEntity _character;
		private IEvent _removeActiveAbilityEvent;

		public void Init(IEntity entity)
		{
			_removeActiveAbilityEvent = entity.GetRemoveActiveAbilityEvent();
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
			_removeActiveAbilityEvent.Invoke();
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