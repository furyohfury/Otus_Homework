using System;
using System.Collections.Generic;
using System.Linq;
using Game;
using SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
	public sealed class LevelMiniaturePresenter
	{
		private readonly string _levelName;
		private readonly string _scene;
		private readonly LevelMiniatureView _view;
		private readonly List<TimeSpan> _savedResults;
		private readonly Sprite _icon;

		private readonly Dictionary<Cups, Sprite> _cupsSprites;
		private readonly Dictionary<Cups, TimeSpan> _targetTimes;

		public LevelMiniaturePresenter(string levelName, string scene, Sprite icon, LevelMiniatureView view
			, List<TimeSpan> savedResults, Dictionary<Cups, Sprite> cupsSprites, Dictionary<Cups, TimeSpan> targetTimes)
		{
			_levelName = levelName;
			_scene = scene;
			_icon = icon;
			_view = view;
			_savedResults = savedResults;
			_cupsSprites = cupsSprites;
			_targetTimes = targetTimes;
		}

		public void Init()
		{
			InitLevelName(_levelName);
			InitIcon();
			InitCupAndBestTime();

			_view.OnChooseLevelButtonClicked += OnChooseLevelButtonClicked;
		}

		private void InitLevelName(string levelName)
		{
			_view.SceneName.text = levelName;
		}

		private void InitIcon()
		{
			_view.Icon.sprite = _icon;
		}

		private void InitCupAndBestTime()
		{
			if (_savedResults != null) // TODO if not initialized. Where it defines
			{
				TimeSpan bestTime = _savedResults.Where(time => time != default)
				                                 .Min();
				var bestTimeText = bestTime.ToString(@"m\:ss\:fff");

				var bestCup = _targetTimes
				              .Where(kvp => kvp.Value > bestTime)
				              .OrderBy(kvp => kvp.Value)
				              .Select(kvp => kvp.Key)
				              .FirstOrDefault();
				if (bestCup != default)
				{
					_view.CupIcon.sprite = _cupsSprites[bestCup];
				}

				_view.BestTime.text = bestTimeText;
			}
		}

		private void OnChooseLevelButtonClicked()
		{
			SceneSystem.SwitchToScene(_scene);
		}

		public void Dispose()
		{
			_view.OnChooseLevelButtonClicked -= OnChooseLevelButtonClicked;
		}
	}
}