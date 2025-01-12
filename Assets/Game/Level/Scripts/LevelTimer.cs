using System;
using System.Diagnostics;

namespace Game
{
	public sealed class LevelTimer : IGameTickable
	{
		public TimeSpan LevelTime => _stopwatch.Elapsed;

		private TimeSpan _levelTime;
		private bool _isActive;
		private readonly Stopwatch _stopwatch = new();

		public void Tick(float deltaTime)
		{
			if (_isActive)
			{
				_levelTime = _levelTime.Add(TimeSpan.FromMilliseconds(deltaTime));
			}
		}

		public void Start()
		{
			_isActive = true;
		}

		public void Finish()
		{
			_isActive = false;
		}

		public void Pause()
		{
			Finish();
		}

		public void Resume()
		{
			Start();
		}
	}
}