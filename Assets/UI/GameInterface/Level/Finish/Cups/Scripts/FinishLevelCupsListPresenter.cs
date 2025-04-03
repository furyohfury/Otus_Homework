using System;
using System.Collections.Generic;
using Game;
using Zenject;

namespace UI
{
	public sealed class FinishLevelCupsListPresenter : IInitializable, IDisposable
	{
		private readonly FinishLevelCupsListView _finishLevelCupsListView;
		private readonly LevelManager _levelManager;
		private readonly LevelTimer _levelTimer;
		private readonly LevelsDataService _levelsDataService;

		[Inject]
		public FinishLevelCupsListPresenter(FinishLevelCupsListView finishLevelCupsListView, LevelManager levelManager, LevelTimer levelTimer
			, LevelsDataService levelsDataService)
		{
			_finishLevelCupsListView = finishLevelCupsListView;
			_levelManager = levelManager;
			_levelTimer = levelTimer;
			_levelsDataService = levelsDataService;
		}


		public void Initialize()
		{
			_levelManager.OnLevelFinished += OnLevelFinished;
			_levelManager.OnLevelStarted += OnLevelStarted;
			_levelManager.OnLevelReset += OnLevelStarted;

			SetTimesText();
		}

		private void SetTimesText()
		{
			var currentLevel = _levelsDataService.GetCurrentLevel();
			_levelsDataService.TryGetLevelTargetTimes(currentLevel, out Dictionary<Cups, TimeSpan> targetTimes);
			foreach (var cup in targetTimes.Keys)
			{
				var time = targetTimes[cup];
				var timeText = time.ToString(@"m\:ss\:fff");
				_finishLevelCupsListView.SetCupTimeText(cup, timeText);
			}
		}

		private void OnLevelStarted()
		{
			_finishLevelCupsListView.HideAll();
		}

		private void OnLevelFinished()
		{
			var currentLevel = _levelsDataService.GetCurrentLevel();
			_levelsDataService.TryGetLevelTargetTimes(currentLevel, out Dictionary<Cups, TimeSpan> targetTimes);
			TimeSpan levelTime = _levelTimer.LevelTime;

			foreach (var cup in targetTimes.Keys)
			{
				if (levelTime <= targetTimes[cup])
				{
					_finishLevelCupsListView.SetCupViewActive(cup, true);
				}
			}
		}

		public void Dispose()
		{
			_levelManager.OnLevelFinished -= OnLevelFinished;
			_levelManager.OnLevelStarted -= OnLevelStarted;
			_levelManager.OnLevelReset -= OnLevelStarted;
		}
	}
}