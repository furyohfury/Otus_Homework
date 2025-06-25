using System;
using System.Collections.Generic;
using Game;
using Zenject;

namespace UI
{
	public sealed class SelectLevelMenuPresenter
	{
		private Dictionary<string, List<TimeSpan>> _savedResults;

		private readonly LevelCardPresenterFactory _presenterFactory;
		private readonly ILevelsDataService _levelsDataService;
		private readonly List<LevelCardPresenter> _levelMiniaturePresenters = new();

		[Inject]
		public SelectLevelMenuPresenter(LevelCardPresenterFactory presenterFactory, ILevelsDataService levelsDataService)
		{
			_presenterFactory = presenterFactory;
			_levelsDataService = levelsDataService;
		}

		public string[] GetLevels()
		{
			return _levelsDataService.GetLevelNames();
		}

		public void OnLevelMiniatureViewCreated(LevelCardView cardView, string level)
		{
			LevelCardPresenter presenter;
			if (_savedResults.TryGetValue(level, out List<TimeSpan> levelResults))
			{
				presenter = _presenterFactory.Create(level, cardView, levelResults);
			}
			else
			{
				presenter = _presenterFactory.Create(level, cardView);
			}

			_levelMiniaturePresenters.Add(presenter);
		}

		public void OnViewShown()
		{
			LoadResultsData();
		}

		public void Clear()
		{
			foreach (var levelMiniaturePresenter in _levelMiniaturePresenters)
			{
				levelMiniaturePresenter.Dispose();
			}

			_levelMiniaturePresenters.Clear();
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