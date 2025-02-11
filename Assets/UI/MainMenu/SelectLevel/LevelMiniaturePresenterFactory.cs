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
		private readonly Dictionary<string, LevelCupsTimesConfig> _cupsTimesConfigs;
		private readonly Dictionary<string, Sprite> _levelIcons;

		private readonly Dictionary<Cups, Sprite> _cupsSprites;

		[Inject]
		public LevelMiniaturePresenterFactory(Dictionary<string, LevelCupsTimesConfig> cupsTimesConfigs
			, IGameRepository gameRepository, Dictionary<Cups, Sprite> cupsSprites, Dictionary<string, Sprite> levelIcons)
		{
			_cupsTimesConfigs = cupsTimesConfigs;
			_cupsSprites = cupsSprites;
			_levelIcons = levelIcons;
		}

		public LevelMiniaturePresenter Create(string level, List<TimeSpan> levelResults, LevelMiniatureView view)
		{
			var cupConfig = _cupsTimesConfigs[level];
			var icon = _levelIcons[level];
			var presenter = new LevelMiniaturePresenter(level,
				icon,
				view,
				cupConfig,
				levelResults,
				_cupsSprites);

			presenter.Init();

			return presenter;
		}
	}
}