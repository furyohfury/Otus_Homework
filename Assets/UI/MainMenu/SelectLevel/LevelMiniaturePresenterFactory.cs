using System;
using System.Collections.Generic;
using Game;
using SaveLoad;
using UnityEngine;
using Zenject;

namespace UI
{
	public sealed class LevelMiniaturePresenterFactory
	{
		private readonly LevelsDataService _levelsDataService;

		private readonly Dictionary<Cups, Sprite> _cupsSprites;

		[Inject]
		public LevelMiniaturePresenterFactory(IGameRepository gameRepository, Dictionary<Cups, Sprite> cupsSprites, LevelsDataService levelsDataService)
		{
			_cupsSprites = cupsSprites;
			_levelsDataService = levelsDataService;
		}

		public LevelMiniaturePresenter Create(string level, List<TimeSpan> levelResults, LevelMiniatureView view)
		{
			_levelsDataService.TryGetLevelTargetTimes(level, out Dictionary<Cups, TimeSpan> targetTimes);
			var icon = _levelsDataService.GetLevelIcon(level);
			var presenter = new LevelMiniaturePresenter(level,
				icon,
				view,
				levelResults,
				_cupsSprites,
				targetTimes);

			presenter.Init();

			return presenter;
		}
	}
}