using System;
using System.Collections.Generic;
using System.Linq;
using Game;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
	public sealed class LevelMiniaturePresenter
	{
		private readonly string _levelName;
		private readonly LevelMiniatureView _view;
		private readonly LevelCupsTimesConfig _levelCupsTimesConfig;
		private readonly List<TimeSpan> _savedResults;
		private readonly Sprite _icon;

		private readonly Dictionary<Cups, Sprite> _cupsSprites;

		public LevelMiniaturePresenter(string levelName, Sprite icon, LevelMiniatureView view, LevelCupsTimesConfig levelCupsTimesConfig
			, List<TimeSpan> savedResults, Dictionary<Cups, Sprite> cupsSprites)
		{
			_levelName = levelName;
			_icon = icon;
			_view = view;
			_levelCupsTimesConfig = levelCupsTimesConfig;
			_savedResults = savedResults;
			_cupsSprites = cupsSprites;
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
			Dictionary<Cups, TimeSpan> targetTimes = _levelCupsTimesConfig.GetTargetTimes();

			string bestTimeText = "No results yet";
			if (_savedResults != null) // TODO if not initialized. Where it defines
			{
				TimeSpan bestTime = _savedResults.Min();
				bestTimeText = bestTime.ToString(@"m\:ss\:fff");

				var bestCup = targetTimes
				              .Where(kvp => kvp.Value > bestTime)
				              .OrderBy(kvp => kvp.Value)
				              .Select(kvp => kvp.Key)
				              .FirstOrDefault();
				if (bestCup != default)
				{
					_view.CupIcon.sprite = _cupsSprites[bestCup];
				}
			}

			_view.BestTime.text = bestTimeText;
		}

		private void OnChooseLevelButtonClicked()
		{
			var sceneName = _view.SceneName.text;
			SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
		}

		public void Dispose()
		{
			_view.OnChooseLevelButtonClicked -= OnChooseLevelButtonClicked;
		}
	}
}