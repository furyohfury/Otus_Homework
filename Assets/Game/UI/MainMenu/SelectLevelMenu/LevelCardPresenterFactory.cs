using System;
using System.Collections.Generic;
using Game;
using SaveLoad;
using UnityEngine;
using Zenject;

namespace UI
{
	public sealed class LevelCardPresenterFactory
	{
		private readonly ILevelsDataService _levelsDataService;

		private readonly Dictionary<Cups, Sprite> _cupsSprites;

		[Inject]
		public LevelCardPresenterFactory(IGameRepository gameRepository, Dictionary<Cups, Sprite> cupsSprites
			, ILevelsDataService levelsDataService)
		{
			_cupsSprites = cupsSprites;
			_levelsDataService = levelsDataService;
		}

		public LevelCardPresenter Create(string level, LevelCardView view, List<TimeSpan> levelResults = null)
		{
			_levelsDataService.TryGetLevelTargetTimes(level, out Dictionary<Cups, TimeSpan> targetTimes);
			var icon = _levelsDataService.GetLevelIcon(level);
			var scene = _levelsDataService.GetSceneName(level);
			var presenter = new LevelCardPresenter(level,
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