using System;
using System.Collections.Generic;
using System.Text;
using Game;
using Zenject;

namespace UI
{
	public sealed class LeaderboardListController : IInitializable, IDisposable
	{
		private readonly SingleTextFieldView _leaderboardListView;
		private readonly LevelManager _levelManager;
		private readonly LeaderboardService _leaderboardService;

		public LeaderboardListController(SingleTextFieldView leaderboardListView, LevelManager levelManager, LeaderboardService leaderboardService)
		{
			_leaderboardListView = leaderboardListView;
			_levelManager = levelManager;
			_leaderboardService = leaderboardService;
		}

		public void Initialize()
		{
			_levelManager.OnLevelFinished += OnLevelFinished;
		}

		private void OnLevelFinished()
		{
			var stringBuilder = new StringBuilder();
			IReadOnlyCollection<TimeSpan> timeLeaderboard = _leaderboardService.TimeLeaderboard;
			foreach (var time in timeLeaderboard)
			{
				if (time == default)
				{
					continue;
				}

				stringBuilder.AppendLine(time.ToString(@"mm\:ss\:fff"));
			}

			_leaderboardListView.SetText(stringBuilder.ToString());
		}

		public void Dispose()
		{
			_levelManager.OnLevelFinished -= OnLevelFinished;
		}
	}
}