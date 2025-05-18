using System;
using Atomic.Elements;
using Atomic.Entities;
using Game;
using Zenject;

namespace UI
{
	public sealed class CharacterAmmoPresenter : IInitializable, IDisposable
	{
		private readonly AmountView _ammoView;
		private readonly PlayerService _playerService;

		private IEntity _character;

		[Inject]
		public CharacterAmmoPresenter(AmountView ammoView, PlayerService playerService)
		{
			_ammoView = ammoView;
			_playerService = playerService;
		}

		public void Initialize()
		{
			_character = _playerService.Player;
			_character.OnValueAdded += OnWeaponAdded;
			_character.OnValueDeleted += OnWeaponRemoved;

			if (_character.TryGetWeapon(out ReactiveVariable<SceneEntity> weapon)
			    && weapon.Value.TryGetAmmo(out ReactiveVariable<int> ammo))
			{
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

			if (_character.TryGetWeapon(out ReactiveVariable<SceneEntity> weapon)
			    && weapon.Value.TryGetAmmo(out ReactiveVariable<int> ammo))
			{
				ammo.Subscribe(OnAmmoChanged);
				OnAmmoChanged(ammo.Value);
			}
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

		private void OnWeaponRemoved(IEntity character, int index, object value)
		{
			if (_character.TryGetAmmo(out ReactiveVariable<int> ammo))
			{
				ammo.Unsubscribe(OnAmmoChanged);
			}

			_ammoView.SetText(string.Empty);
		}

		public void Dispose()
		{
			_character.OnValueAdded -= OnWeaponAdded;
			_character.OnValueDeleted += OnWeaponRemoved;
		}
	}
}