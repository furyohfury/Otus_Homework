using System;
using System.Collections.Generic;
using ObservableCollections;
using Zenject;

namespace Game
{
	public sealed class Leaderboard : IInitializable, IDisposable
	{
		public IReadOnlyObservableList<TimeSpan> Times => _times;
		private readonly ObservableList<TimeSpan> _times = new(5);

		private readonly LevelManager _levelManager;
		private readonly LevelTimer _levelTimer;
		private const int LEADERBOARD_SIZE = 5;

		[Inject]
		public Leaderboard(LevelManager levelManager, LevelTimer levelTimer)
		{
			_levelManager = levelManager;
			_levelTimer = levelTimer;
		}

		public void Initialize()
		{
			_levelManager.OnLevelFinished += OnLevelFinished;
			for (int i = 0; i < LEADERBOARD_SIZE; i++)
			{
				_times.Add(default);
			}
		}

		public void SetLeaderboard(IList<TimeSpan> times)
		{
			for (int i = 0, count = _times.Count; i < count; i++)
			{
				_times[i] = times[i];
			}
		}

		private void OnLevelFinished()
		{
			TimeSpan levelTime = _levelTimer.LevelTime;

			ReplaceTimeInLeaderboard(levelTime);
		}

		private void ReplaceTimeInLeaderboard(TimeSpan levelTime)
		{
			for (var i = 0; i < _times.Count; i++)
			{
				if (_times[i] == default)
				{
					_times[i] = levelTime;
					break;
				}

				if (levelTime < _times[i])
				{
					_times[^1] = levelTime;
					break;
				}
			}

			_times.Sort();
		}

		public void Dispose()
		{
			_levelManager.OnLevelFinished += OnLevelFinished;
		}
	}
}