using System;
using Game;
using SceneManagement;
using Zenject;

namespace UI
{
	public sealed class FinishLevelMenuPresenter : IInitializable, IDisposable
	{
		private readonly FinishLevelMenuView _view;
		private readonly LevelManager _levelManager;

		[Inject]
		public FinishLevelMenuPresenter(FinishLevelMenuView view, LevelManager levelManager)
		{
			_view = view;
			_levelManager = levelManager;
		}

		public void Initialize()
		{
			_levelManager.OnLevelFinished += OnLevelFinished;
			_view.OnRetryButtonClicked += OnRetryButtonClicked;
			_view.OnMainMenuButtonClicked += OnMainMenuButtonClicked;
		}

		private void OnLevelFinished()
		{
			ShowView();
		}

		private void OnRetryButtonClicked()
		{
			HideView();
			_levelManager.ResetLevel();
		}

		private void OnMainMenuButtonClicked()
		{
			SceneSystem.SwitchToScene(SceneNames.MAIN_MENU_SCENE);
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
			_view.OnRetryButtonClicked -= OnRetryButtonClicked;
			_view.OnMainMenuButtonClicked -= OnMainMenuButtonClicked;
		}
	}
}