using System;
using Atomic.Elements;
using Atomic.Entities;
using Game;
using UnityEngine;
using Zenject;

namespace UI
{
	public sealed class GameOverMenuPresenter : IInitializable, IDisposable, IGameTickable
	{
		private readonly GameOverMenuView _view;
		private readonly LevelManager _levelManager;
		private readonly IEntity _character;
		private IFunction<bool> _playerIsDead;
		private readonly GameStateManager _gameStateManager;

		[Inject]
		public GameOverMenuPresenter(GameOverMenuView view, LevelManager levelManager, IEntity character, GameStateManager gameStateManager)
		{
			_view = view;
			_levelManager = levelManager;
			_character = character;
			_gameStateManager = gameStateManager;
		}

		public void Initialize()
		{
			_view.OnResetButtonClicked += OnResetButtonClicked;
			_view.OnMainMenuButtonClicked += OnMainMenuButtonClicked;

			if (_character.TryGetIsDead(out BaseFunction<bool> isDead) == false)
			{
				Debug.LogError("Cant find isDead on player");
				return;
			}

			_playerIsDead = isDead;
		}

		private void OnResetButtonClicked()
		{
			_view.gameObject.SetActive(false);
			_levelManager.ResetLevel();
		}

		private void OnMainMenuButtonClicked()
		{
			// TODO common logic
		}

		public void Tick(float deltaTime)
		{
			if (_playerIsDead.Invoke())
			{
				_gameStateManager.ChangeState(GameState.Pause);
				_view.gameObject.SetActive(true);
			}
		}

		public void Dispose()
		{
			_view.OnResetButtonClicked -= OnResetButtonClicked;
			_view.OnMainMenuButtonClicked -= OnMainMenuButtonClicked;
		}
	}
}