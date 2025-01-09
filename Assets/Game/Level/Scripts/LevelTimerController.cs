using System;
using Zenject;

namespace Game
{
	public sealed class LevelTimerController : IInitializable, IDisposable
	{
		private readonly LevelTimer _levelTimer;
		private readonly LevelManager _levelManager;

		[Inject]
		public LevelTimerController(LevelTimer levelTimer, LevelManager levelManager)
		{
			_levelTimer = levelTimer;
			_levelManager = levelManager;
		}

		public void Initialize()
		{
			_levelManager.OnLevelStarted += StartTimer;
			_levelManager.OnLevelFinished += StopTimer;
		}

		private void StartTimer()
		{
			_levelTimer.StartTimer();
		}

		private void StopTimer()
		{
			_levelTimer.FinishTimer();
		}

		public void Dispose()
		{
			_levelManager.OnLevelStarted -= StartTimer;
			_levelManager.OnLevelFinished -= StopTimer;
		}
	}
}