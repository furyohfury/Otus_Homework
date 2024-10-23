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
		[SerializeField] [JsonProperty]
		private float _initialDurationInSeconds;
		[JsonProperty]
		private DateTime _finishTime;
		private bool _initialized;

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