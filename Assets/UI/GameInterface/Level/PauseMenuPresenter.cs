using System;
using Game;
using Zenject;

namespace UI
{
	public sealed class PauseMenuPresenter : IInitializable, IDisposable
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
			_view.OnResumeButtonClicked += OnResumeButtonClicked;
			_view.OnResetButtonClicked += OnResetButtonClicked;
			_view.OnMainMenuButtonClicked += OnMainMenuButtonClicked;
			_gameStateManager.OnStateChanged += OnStateChanged;
		}

		private void OnResumeButtonClicked()
		{
			DeactivateView();
			_gameStateManager.ChangeState(GameState.Resume);
		}

		private void OnResetButtonClicked()
		{
			DeactivateView();
			_levelManager.ResetLevel();
		}

		private void OnMainMenuButtonClicked()
		{
			// TODO common logic
		}

		private void OnStateChanged(GameState state)
		{
			if (state == GameState.Resume)
			{
				DeactivateView();
			}

			if (state == GameState.Pause)
			{
				ActivateView();
			}
		}

		private void ActivateView() => _view.gameObject.SetActive(true);

		private void DeactivateView() => _view.gameObject.SetActive(false);

		public void Dispose()
		{
			_view.OnResumeButtonClicked -= OnResumeButtonClicked;
			_view.OnResetButtonClicked -= OnResetButtonClicked;
			_view.OnMainMenuButtonClicked -= OnMainMenuButtonClicked;
		}
	}
}