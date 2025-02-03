using System;
using System.Collections.Generic;
using Game;
using Zenject;

namespace UI
{
	public sealed class CupsListPresenter : IInitializable, IDisposable
	{
		private readonly CupsListView _cupsListView;
		private readonly LevelCupsTimesConfig _levelCupsTimesConfig;
		private readonly LevelManager _levelManager;
		private readonly LevelTimer _levelTimer;

		[Inject]
		public CupsListPresenter(CupsListView cupsListView, LevelCupsTimesConfig levelCupsTimesConfig, LevelManager levelManager
			, LevelTimer levelTimer)
		{
			_cupsListView = cupsListView;
			_levelCupsTimesConfig = levelCupsTimesConfig;
			_levelManager = levelManager;
			_levelTimer = levelTimer;
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
			Dictionary<Cups, TimeSpan> timesConfig = _levelCupsTimesConfig.GetTargetTimes();
			foreach (var cup in timesConfig.Keys)
			{
				var time = timesConfig[cup];
				var timeText = time.ToString(@"m\:ss\:fff");
				_cupsListView.SetCupTimeText(cup, timeText);
			}
		}

		private void OnLevelStarted()
		{
			_cupsListView.HideAll();
		}

		private void OnLevelFinished()
		{
			TimeSpan levelTime = _levelTimer.LevelTime;
			Dictionary<Cups, TimeSpan> targetTimes = _levelCupsTimesConfig.GetTargetTimes();

			foreach (var cup in targetTimes.Keys)
			{
				if (levelTime <= targetTimes[cup])
				{
					_cupsListView.SetCupViewActive(cup, true);
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