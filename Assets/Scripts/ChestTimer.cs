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
		private DateTime _finishTime; // to save
		private TimeSpan _timeLeft;

		public async UniTask Initialize()
		{
			if (_finishTime == default)
			{
				_finishTime = TimeSpan.FromSeconds(_initialDurationInSeconds);
			}

			var serverTimeRequest = await ServerTimeManager.TryGetServerTimeAsync();
			if (serverTimeRequest.successful)
			{
				_timeLeft = _finishTime - serverTimeRequest.serverTime;
			}
		}
	}
}