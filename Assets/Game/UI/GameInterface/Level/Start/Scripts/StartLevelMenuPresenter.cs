using System;
using Game;
using SceneControls;
using Zenject;

namespace UI
{
	public sealed class StartLevelMenuPresenter : IInitializable, IDisposable
	{
		private readonly StartLevelMenuView _view;
		private readonly LevelManager _levelManager;
		private readonly GameStateManager _gameStateManager;

		[Inject]
		public StartLevelMenuPresenter(StartLevelMenuView view, LevelManager levelManager, GameStateManager gameStateManager)
		{
			_view = view;
			_levelManager = levelManager;
			_gameStateManager = gameStateManager;
		}

		public void Initialize()
		{
			_view.OnPlayButtonClicked += OnPlayButtonClicked;
			_view.OnMainMenuButtonClicked += OnMainMenuButtonClicked;
			_levelManager.OnLevelReset += OnLevelReset;
		}

		private void OnPlayButtonClicked()
		{
			_view.gameObject.SetActive(false);
			_levelManager.StartLevel();

			var currentState = _gameStateManager.State;
			if (currentState == GameState.Pause)
			{
				_gameStateManager.ChangeState(GameState.Resume);
			}
		}

		private async void OnMainMenuButtonClicked()
		{
			await SceneSystem.SwitchToScene(SceneNames.MAIN_MENU_SCENE);
		}

		private void OnLevelReset()
		{
			_view.gameObject.SetActive(true);
		}

		public void Dispose()
		{
			_view.OnPlayButtonClicked -= OnPlayButtonClicked;
			_view.OnMainMenuButtonClicked -= OnMainMenuButtonClicked;
			_levelManager.OnLevelReset -= OnLevelReset;
		}
	}
}