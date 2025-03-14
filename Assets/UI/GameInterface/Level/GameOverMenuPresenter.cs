using System;
using Atomic.Elements;
using Atomic.Entities;
using Game;
using SceneManagement;
using UnityEngine;
using Zenject;
using SceneNames = Game.SceneNames;

namespace UI
{
	public sealed class GameOverMenuPresenter : IInitializable, IDisposable, IGameTickable
	{
		private readonly PlayerService _playerService;
		private IFunction<bool> _playerIsDead;

		private readonly GameOverMenuView _view;
		private readonly LevelManager _levelManager;
		private readonly GameStateManager _gameStateManager;

		[Inject]
		public GameOverMenuPresenter(GameOverMenuView view, LevelManager levelManager, GameStateManager gameStateManager, PlayerService playerService)
		{
			_view = view;
			_levelManager = levelManager;
			_gameStateManager = gameStateManager;
			_playerService = playerService;
		}

		public void Initialize()
		{
			_view.OnResetButtonClicked += OnResetButtonClicked;
			_view.OnMainMenuButtonClicked += OnMainMenuButtonClicked;

			if (_playerService.Player.TryGetIsDead(out BaseFunction<bool> isDead) == false)
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
			SceneSystem.SwitchToScene(SceneNames.MAIN_MENU_SCENE);
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