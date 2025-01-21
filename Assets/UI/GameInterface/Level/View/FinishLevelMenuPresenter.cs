using System;
using System.Text;
using Game;
using Zenject;

namespace UI
{
	public sealed class FinishLevelMenuPresenter : IInitializable, IDisposable
	{
		private readonly FinishLevelMenuView _view;
		private readonly LevelManager _levelManager;
		private readonly Leaderboard _leaderboard;

		[Inject]
		public FinishLevelMenuPresenter(FinishLevelMenuView view, LevelManager levelManager, Leaderboard leaderboard)
		{
			_view = view;
			_levelManager = levelManager;
			_leaderboard = leaderboard;
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
			var leaderboardTime = _leaderboard.Times;
			var sb = new StringBuilder();
			for (int i = 0, count = leaderboardTime.Count; i < count; i++)
			{
				if (leaderboardTime[i] != default)
				{
					sb.AppendLine(leaderboardTime[i].ToString("g"));
				}
			}

			_view.UpdateLeaderboard(sb.ToString());
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