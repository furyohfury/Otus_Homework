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
		public event Action OnFinished;
		public TimeSpan TimeLeft => TimeSpan.FromSeconds(_durationInSeconds);

		[SerializeField]
		private int _initialDurationInSeconds;
		private int _durationInSeconds;
		
		private CompositeDisposable _disposable = new();

		public void Initialize()
		{
			Observable
				.Interval(TimeSpan.FromSeconds(1f))
				.Subscribe(_ => DecrementSecond())
				.AddTo(_disposable);
		}

		public void Restart()
		{
			_disposable.Clear();
			_durationInSeconds = _initialDurationInSeconds;
			Initialize();
		}

		private void DecrementSecond()
		{
			_durationInSeconds -= 1;
			if (_durationInSeconds <= 0)
			{
				_disposable.Clear();
				OnFinished?.Invoke();
			}
		}
	}
}