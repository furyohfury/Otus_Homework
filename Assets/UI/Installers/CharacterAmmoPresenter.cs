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
			_character.OnValueAdded += OnAmmoAdded;
			
			if (_character.TryGetAmmo(out ReactiveVariable<int> ammo))
			{
				var ammoSize = _character.GetAmmoSize().Value;
				_ammoView.SetText($"{ammo}/{ammoSize}");
			}
			else
			{
				_ammoView.SetText(string.Empty);
			}
		}

		private void OnAmmoAdded(IEntity character, int count, object value)
		{
			if (count != CombatAPI.Ammo)
			{
				return;
			}

			OnAmmoChanged(_character.GetAmmo().Value);
			_character.GetAmmo().Subscribe(OnAmmoChanged);
		}

		private void OnAmmoChanged(int count)
		{
			if (count <= 0)
			{
				_ammoView.SetText(string.Empty);
				_character.GetAmmo().Unsubscribe(OnAmmoChanged);
				return;
			}

			var maxAmmo = _character.GetAmmoSize().Value;
			var text = $"{count}/{maxAmmo}";
			_ammoView.SetText(text);
		}

		public void Dispose()
		{
			_character.OnValueAdded -= OnAmmoAdded;
		}
	}
}