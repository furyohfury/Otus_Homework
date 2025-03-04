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
		public LevelMiniaturePresenterFactory(IGameRepository gameRepository, Dictionary<Cups, Sprite> cupsSprites
			, LevelsDataService levelsDataService)
		{
			_cupsSprites = cupsSprites;
			_levelsDataService = levelsDataService;
		}

		public LevelMiniaturePresenter Create(string level, LevelMiniatureView view, List<TimeSpan> levelResults = null)
		{
			_levelsDataService.TryGetLevelTargetTimes(level, out Dictionary<Cups, TimeSpan> targetTimes);
			var icon = _levelsDataService.GetLevelIcon(level);
			var scene = _levelsDataService.GetSceneName(level);
			var presenter = new LevelMiniaturePresenter(level,
				scene,
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