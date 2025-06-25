using System;
using System.Collections.Generic;
using System.Linq;
using Game;
using ObservableCollections;
using Zenject;
using IInitializable = Zenject.IInitializable;

namespace SaveLoad
{
	public sealed class LeaderboardSaveController : IInitializable, IDisposable
	{
		private readonly Leaderboard _leaderboard;
		private readonly ILevelsDataService _levelsDataService;
		private readonly SaveLoadManager _saveLoadManager;
		private string _levelName;

		[Inject]
		public LeaderboardSaveController(Leaderboard leaderboard, ILevelsDataService levelsDataService, SaveLoadManager saveLoadManager)
		{
			_leaderboard = leaderboard;
			_levelsDataService = levelsDataService;
			_saveLoadManager = saveLoadManager;
		}

		public void Initialize()
		{
			_levelName = _levelsDataService.GetCurrentLevel();

			_leaderboard.Times.CollectionChanged += OnTimesChanged;
			LoadLeaderboards();
		}

		private void LoadLeaderboards()
		{
			if (_levelsDataService.TryGetLevelResults(_levelName, out List<TimeSpan> results))
			{
				_leaderboard.SetLeaderboard(results);
			}
		}

		private void OnTimesChanged(in NotifyCollectionChangedEventArgs<TimeSpan> _)
		{
			Save();
		}

		private void Save()
		{
			List<TimeSpan> currentSceneLeaderboard = _leaderboard.Times.ToList();
			_levelsDataService.SetResult(_levelName, currentSceneLeaderboard);
			_saveLoadManager.SaveSpecific<LevelResultsSaveLoader>();
		}

		public void Dispose()
		{
			_leaderboard.Times.CollectionChanged -= OnTimesChanged;
		}
	}
}