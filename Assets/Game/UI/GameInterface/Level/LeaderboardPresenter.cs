using System;
using System.Text;
using Game;
using ObservableCollections;
using Zenject;

namespace UI
{
	public sealed class LeaderboardPresenter : IInitializable, IDisposable
	{
		private readonly Leaderboard _leaderboard;
		private readonly AmountView _view;

		public LeaderboardPresenter(Leaderboard leaderboard, AmountView view)
		{
			_leaderboard = leaderboard;
			_view = view;
		}

		public void Initialize()
		{
			_leaderboard.Times.CollectionChanged += OnLeaderboardChanged;
			UpdateLeaderboardText();
		}

		private void OnLeaderboardChanged(in NotifyCollectionChangedEventArgs<TimeSpan> e)
		{
			UpdateLeaderboardText();
		}

		private void UpdateLeaderboardText()
		{
			var leaderboardTime = _leaderboard.Times;
			var sb = new StringBuilder();
			for (int i = 0, count = leaderboardTime.Count; i < count; i++)
			{
				if (leaderboardTime[i] != default)
				{
					sb.AppendLine(leaderboardTime[i].ToString(@"m\:ss\:fff"));
				}
			}

			_view.SetText(sb.ToString());
		}

		public void Dispose()
		{
			_leaderboard.Times.CollectionChanged -= OnLeaderboardChanged;
		}
	}
}