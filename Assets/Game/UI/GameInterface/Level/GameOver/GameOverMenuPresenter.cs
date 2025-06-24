using System;
using Atomic.Elements;
using Atomic.Entities;
using Game;
using SceneControls;
using UnityEngine;
using Zenject;
using SceneNames = Game.SceneNames;

namespace UI
{
	public sealed class GameOverMenuPresenter : IInitializable, IDisposable, IGameTickable
	{
		private readonly PlayerService _playerService;
		private IFunction<bool> _playerIsDead;

		private readonly GameOverMenuView _gameOverView;
		private readonly LevelManager _levelManager;

		[Inject]
		public GameOverMenuPresenter(GameOverMenuView view, LevelManager levelManager, PlayerService playerService)
		{
			_gameOverView = view;
			_levelManager = levelManager;
			_playerService = playerService;
		}

		public void Initialize()
		{
			_gameOverView.OnResetButtonClicked += OnResetButtonClicked;
			_gameOverView.OnMainMenuButtonClicked += OnMainMenuButtonClicked;

			if (_playerService.Player.TryGetIsDead(out BaseFunction<bool> isDead) == false)
			{
				Debug.LogError("Cant find isDead on player");
				return;
			}

			_playerIsDead = isDead;
		}

		private void OnResetButtonClicked()
		{
			_gameOverView.gameObject.SetActive(false);
			_levelManager.ResetLevel();
		}

		private async void OnMainMenuButtonClicked()
		{
			await SceneSystem.SwitchToScene(SceneNames.MAIN_MENU_SCENE);
		}

		public void Tick(float deltaTime)
		{
			if (_playerIsDead.Invoke())
			{
				_levelManager.PauseLevel();
				_gameOverView.gameObject.SetActive(true);
			}
		}

		public void Dispose()
		{
			_gameOverView.OnResetButtonClicked -= OnResetButtonClicked;
			_gameOverView.OnMainMenuButtonClicked -= OnMainMenuButtonClicked;
		}
	}
}