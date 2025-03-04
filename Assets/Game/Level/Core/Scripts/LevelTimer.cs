using System;
using System.Diagnostics;

namespace Game
{
	public sealed class LevelTimer : IGameTickable
	{
		public TimeSpan LevelTime => _levelTime;

		private TimeSpan _levelTime;
		private bool _isActive;

		public void Tick(float deltaTime)
		{
			if (_isActive)
			{
				_levelTime = _levelTime.Add(TimeSpan.FromSeconds(deltaTime));
			}
		}

		public void Start() => _isActive = true;

		public void Finish() => _isActive = false;

		public void Pause() => Finish();

		public void Resume() => Start();

		public void Reset() => _levelTime = TimeSpan.Zero;
	}
}