using System;
using Atomic.Elements;
using Atomic.Entities;
using Game;
using UnityEngine;
using Zenject;

namespace UI
{
	public sealed class CharacterHealthPresenter : IInitializable, IDisposable
	{
		private readonly AmountView _healthUIView;
		private ReactiveVariable<int> _health;
		private readonly PlayerService _playerService;

		[Inject]
		public CharacterHealthPresenter(AmountView healthUIView, PlayerService playerService)
		{
			_healthUIView = healthUIView;
			_playerService = playerService;
		}

		public void Initialize()
		{
			if (!_playerService.Player.TryGetHealth(out ReactiveVariable<int> health))
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