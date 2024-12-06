using System;
using Atomic.Elements;
using Atomic.Entities;
using Zenject;

namespace UI
{
	public sealed class CharacterAmmoPresenter : IInitializable, IDisposable
	{
		private readonly SingleTextFieldView _ammoView;
		private readonly IEntity _character;

		[Inject]
		public CharacterAmmoPresenter(SingleTextFieldView ammoView, IEntity character)
		{
			_ammoView = ammoView;
			_character = character;
		}

		public void Initialize()
		{
			_character.OnValueAdded += OnWeaponAdded;
			_character.OnValueDeleted += OnWeaponDeleted;
			
			if (_character.TryGetWeapon(out ReactiveVariable<SceneEntity> weapon))
			{
				ReactiveVariable<int> ammo = weapon.Value.GetAmmo();
				ammo.Subscribe(OnAmmoChanged);
				OnAmmoChanged(ammo.Value);
			}
			else
			{
				_ammoView.SetText(string.Empty);
			}
		}

		private void OnWeaponAdded(IEntity character, int index, object value)
		{
			if (index != CombatAPI.Weapon)
			{
				return;
			}

			ReactiveVariable<SceneEntity> weapon = character.GetWeapon();
			ReactiveVariable<int> ammo = weapon.Value.GetAmmo();
			
			OnAmmoChanged(ammo.Value);
			ammo.Subscribe(OnAmmoChanged);
		}

		private void OnAmmoChanged(int count)
		{
			if (count <= 0)
			{
				_ammoView.SetText(string.Empty);
				if (_character.TryGetWeapon(out var weapon)
				    && _character.TryGetAmmo(out ReactiveVariable<int> ammo))
				{
					ammo.Unsubscribe(OnAmmoChanged);
				}
				
				return;
			}

			var characterWeapon = _character.GetWeapon().Value;
			var maxAmmo = characterWeapon.GetAmmoSize().Value;
			var text = $"{count.ToString()}/{maxAmmo.ToString()}";
			_ammoView.SetText(text);
		}

		private void OnWeaponDeleted(IEntity character, int index, object value)
		{
			if (_character.TryGetAmmo(out ReactiveVariable<int> ammo))
			{
				ammo.Unsubscribe(OnAmmoChanged);
			}
		}

		public void Dispose()
		{
			_character.OnValueAdded -= OnWeaponAdded;
		}
	}
}