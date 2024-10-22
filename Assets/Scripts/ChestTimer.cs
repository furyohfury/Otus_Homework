using System;
using Cysharp.Threading.Tasks;
using Newtonsoft.Json;
using UniRx;
using UnityEngine;

namespace RealTime
{
	[Serializable]
	public sealed class ChestTimer
	{	
		[SerializeField]
		private float _initialDurationInSeconds; // to save
		private DateTime _finishTime; // to save. Check if saves default or null if not initialized
		private bool _initialized = false;

		public void Initialize()
		{
			if (!ServerTimeManager.Instance.TryGetCurrentTime(out DateTime currentTime)) return;
						
			if (_finishTime == default) // First time initialization
			{
				var duration = TimeSpan.FromSeconds(_initialDurationInSeconds);
				_finishTime = currentTime + duration;
			}			
			_initialized = true;		
		}

		public bool TryGetTimeLeft(out TimeSpan timeLeft)
		{
			if (!_initialized || !ServerTimeManager.Instance.TryGetCurrentTime(out DateTime currentTime))
			{
				timeLeft = default;
				return false;
			}

			timeLeft = _finishTime - currentTime;
			return true;
		}

		public void Restart()
		{
			_finishTime = default;
			_initialized = false;
			Initialize();
		}
	}
}