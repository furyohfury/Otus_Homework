using System;
using Game;
using SceneManagement;
using Zenject;

namespace UI
{
	public sealed class PauseMenuPresenter : IInitializable, IDisposable // TODO appears when char dies
	{
		private readonly PauseMenuView _view;
		private readonly GameStateManager _gameStateManager;
		private readonly LevelManager _levelManager;

		[Inject]
		public PauseMenuPresenter(PauseMenuView view, GameStateManager gameStateManager, LevelManager levelManager)
		{
			_view = view;
			_gameStateManager = gameStateManager;
			_levelManager = levelManager;
		}

		public void Initialize()
		{
			_gameStateManager.OnStateChanged += OnStateChanged;
			_view.OnResumeButtonClicked += OnResumeButtonClicked;
			_view.OnResetButtonClicked += OnResetButtonClicked;
			_view.OnMainMenuButtonClicked += OnMainMenuButtonClicked;
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
			_gameStateManager.OnStateChanged -= OnStateChanged;

			_view.OnResumeButtonClicked -= OnResumeButtonClicked;
			_view.OnResetButtonClicked -= OnResetButtonClicked;
			_view.OnMainMenuButtonClicked -= OnMainMenuButtonClicked;
		}
	}
}