using System;
using System.Collections.Generic;
using Game;
using SaveLoad;
using Zenject;

namespace UI
{
	public sealed class SelectLevelMenuPresenter
	{
		private Dictionary<string, List<TimeSpan>> _savedResults;

		private readonly LevelMiniaturePresenterFactory _presenterFactory;
		private readonly LevelsDataService _levelsDataService;

		[Inject]
		public SelectLevelMenuPresenter(LevelMiniaturePresenterFactory presenterFactory, LevelsDataService levelsDataService)
		{
			_presenterFactory = presenterFactory;
			_levelsDataService = levelsDataService;
		}

		public string[] GetLevels()
		{
			return _levelsDataService.GetLevelNames();
		}

		public void OnLevelMiniatureViewCreated(LevelMiniatureView miniatureView, string level)
		{
			if (_savedResults.TryGetValue(level, out List<TimeSpan> levelResults))
			{
				_presenterFactory.Create(level, miniatureView, levelResults);
			}
			else
			{
				_presenterFactory.Create(level, miniatureView);
			}
		}

		public void OnViewShown()
		{
			LoadResultsData();
		}

		private void LoadResultsData()
		{
			_savedResults = new Dictionary<string, List<TimeSpan>>();
			foreach (var levelName in _levelsDataService.GetLevelNames())
			{
				if (_levelsDataService.TryGetLevelResults(levelName, out var savedResults))
				{
					_savedResults.Add(levelName, savedResults);
				}
			}
		}
	}
}