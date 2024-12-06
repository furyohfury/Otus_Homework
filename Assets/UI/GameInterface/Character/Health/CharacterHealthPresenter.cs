using System;
using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;
using Zenject;

namespace UI
{
	public sealed class CharacterHealthPresenter : IInitializable, IDisposable
	{
		private readonly SingleTextFieldView _healthUIView;
		private readonly IEntity _character;
		private ReactiveVariable<int> _health;

		[Inject]
		public CharacterHealthPresenter(SingleTextFieldView healthUIView, IEntity character)
		{
			_healthUIView = healthUIView;
			_character = character;
		}

		public void Initialize()
		{
			if (!_character.TryGetHealth(out ReactiveVariable<int> health))
			{
				Debug.LogError("Character has no health state");
				return;
			}

			_health = health;
			_health.Subscribe(OnHealthChanged);
			_healthUIView.SetText(_health.Value.ToString());
		}

		private void OnHealthChanged(int hp)
		{
			_healthUIView.SetText(_health.Value.ToString());
		}

		public void Dispose()
		{
			_health?.Unsubscribe(OnHealthChanged);
		}
	}
}