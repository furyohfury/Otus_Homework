using System;
using System.Diagnostics;
using Debug = UnityEngine.Debug;

namespace Game
{
	public sealed class LevelTimer
	{
		public TimeSpan LevelTime => _stopwatch.Elapsed;
		private readonly Stopwatch _stopwatch = new();

		public void StartTimer()
		{
			_stopwatch.Restart();
		}

		public void FinishTimer()
		{
			_stopwatch.Stop();
		}

		public void PauseTimer()
		{
			_stopwatch.Stop();
		}

		public void ResumeTimer()
		{
			_stopwatch.Start();
		}
	}
}