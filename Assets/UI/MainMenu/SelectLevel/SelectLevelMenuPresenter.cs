using System;
using System.Collections.Generic;
using Game;
using SaveLoad;
using UnityEngine;
using Zenject;

namespace UI
{
	public sealed class SelectLevelMenuPresenter
	{
		public string[] Levels => LevelNames.Names;

		private Dictionary<string, List<TimeSpan>> _savedResults;

		private readonly LevelMiniaturePresenterFactory _presenterFactory;
		private readonly IGameRepository _gameRepository;

		[Inject]
		public SelectLevelMenuPresenter(LevelMiniaturePresenterFactory presenterFactory, IGameRepository gameRepository)
		{
			_presenterFactory = presenterFactory;
			_gameRepository = gameRepository;
		}

		public void OnLevelMiniatureViewCreated(LevelMiniatureView miniatureView, string level)
		{
			if (_savedResults.TryGetValue(level, out List<TimeSpan> levelResults))
			{
				_presenterFactory.Create(level, levelResults, miniatureView);
			}
			// TODO no data for level
		}

		public void OnViewShown()
		{
			LoadResultsData();
		}

		private void LoadResultsData()
		{
			if (_gameRepository.TryGetData(out Dictionary<string, List<TimeSpan>> savedResults))
			{
				_savedResults = savedResults;
			}
			else
			{
				Debug.LogError("No saved results for levels");
			}
		}
	}
}