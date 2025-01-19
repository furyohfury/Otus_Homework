using System;
using Game;
using Zenject;

namespace UI
{
	public sealed class FinishLevelMenuPresenter : IInitializable, IDisposable
	{
		private readonly FinishLevelMenuView _view;
		private readonly LevelManager _levelManager;
		// private LeaderboardService _leaderboardService; TODO 

		[Inject]
		public FinishLevelMenuPresenter(FinishLevelMenuView view, LevelManager levelManager)
		{
			_view = view;
			_levelManager = levelManager;
		}

		public void Initialize()
		{
			_view.OnRetryButtonClicked += OnRetryButtonClicked;
			_view.OnMainMenuButtonClicked += OnMainMenuButtonClicked;
			_levelManager.OnLevelFinished += OnLevelFinished;
		}

		private void OnRetryButtonClicked()
		{
			HideView();
			_levelManager.ResetLevel();
		}

		private void OnMainMenuButtonClicked()
		{
			// TODO common logic
		}

		private void OnLevelFinished()
		{
			ShowView();
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