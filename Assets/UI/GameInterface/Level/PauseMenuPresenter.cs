using System;
using Game;
using SceneManagement;
using Zenject;

namespace UI
{
	public sealed class PauseMenuPresenter : IInitializable, IDisposable // TODO appears when char dies
	{
		private readonly PauseMenuView _view;
		private readonly LevelManager _levelManager;
		private readonly GameStateManager _gameStateManager;

		[Inject]
		public PauseMenuPresenter(PauseMenuView view, LevelManager levelManager, GameStateManager gameStateManager)
		{
			_view = view;
			_levelManager = levelManager;
			_gameStateManager = gameStateManager;
		}

		public void Initialize()
		{
			_levelManager.OnLevelStarted += OnLevelStarted;
			_levelManager.OnLevelFinished += OnLevelFinished;
			
			_view.OnResumeButtonClicked += OnResumeButtonClicked;
			_view.OnResetButtonClicked += OnResetButtonClicked;
			_view.OnMainMenuButtonClicked += OnMainMenuButtonClicked;
		}

		private void OnLevelStarted()
		{
			_gameStateManager.OnStateChanged += OnStateChanged;
		}

		private void OnLevelFinished()
		{
			_gameStateManager.OnStateChanged -= OnStateChanged;
		}

		private void OnResumeButtonClicked()
		{
			HideView();
			_gameStateManager.ChangeState(GameState.Resume);
		}

		private void OnResetButtonClicked()
		{
			HideView();
			_levelManager.ResetLevel();
		}

		private void OnMainMenuButtonClicked()
		{
			SceneSystem.SwitchToScene(SceneNames.MAIN_MENU_SCENE);
		}

		private void OnStateChanged(GameState state)
		{
			if (state == GameState.Resume && _view.isActiveAndEnabled)
			{
				HideView();
			}

			if (state == GameState.Pause && _view.isActiveAndEnabled == false)
			{
				ShowView();
			}
		}

		private void ShowView()
		{
			_view.gameObject.SetActive(true);
		}

		private void HideView()
		{
			_view.gameObject.SetActive(false);
		}

		public void Dispose()
		{
			_levelManager.OnLevelStarted -= OnLevelStarted;
			_levelManager.OnLevelFinished -= OnLevelFinished;
			
			_view.OnResumeButtonClicked -= OnResumeButtonClicked;
			_view.OnResetButtonClicked -= OnResetButtonClicked;
			_view.OnMainMenuButtonClicked -= OnMainMenuButtonClicked;
		}
	}
}