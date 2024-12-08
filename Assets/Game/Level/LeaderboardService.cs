using System;
using System.Collections.Generic;
using System.Linq;
using Zenject;

namespace Game
{
	public sealed class LeaderboardService : IInitializable, IDisposable
	{
		public IReadOnlyCollection<TimeSpan> TimeLeaderboard => _timeLeaderboard;

		private TimeSpan[] _timeLeaderboard = new TimeSpan[5]; // TODO INIT from saves
		private readonly LevelManager _levelManager;
		private readonly LevelTimer _levelTimer;

		[Inject]
		public LeaderboardService(LevelManager levelManager, LevelTimer levelTimer)
		{
			_levelManager = levelManager;
			_levelTimer = levelTimer;
		}

		public void Initialize()
		{
			_levelManager.OnLevelFinished += OnLevelFinished;
		}

		public void InitializeLeaderboard(TimeSpan[] times)
		{
			_timeLeaderboard = times;
		}

		private void OnLevelFinished()
		{
			TimeSpan passTime = _levelTimer.LevelTime;

			ReplaceTimeInLeaderboard(passTime);
		}

		private void ReplaceTimeInLeaderboard(TimeSpan passTime)
		{
			for (var i = 0; i < _timeLeaderboard.Length; i++)
			{
				if (_timeLeaderboard[i] != default
				    && _timeLeaderboard[i] > passTime)
				{
					_timeLeaderboard[i] = passTime;
					_timeLeaderboard = _timeLeaderboard.OrderBy(time => time).ToArray();
					break;
				}
			}
		}

		public void Dispose()
		{
			_levelManager.OnLevelFinished += OnLevelFinished;
		}
	}
}