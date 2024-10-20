using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Newtonsoft.Json;
using Sirenix.OdinInspector;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace RealTime
{
	public sealed class Chest : SerializedMonoBehaviour
	{
		[SerializeReference] [JsonProperty]
		private IReward _reward;
		[SerializeField] [JsonProperty]
		private ChestType _chestType;
		[SerializeField] [JsonProperty]
		private ChestTimer _timer;
		
		private CompositeDisposable _disposable = new();

		private void OnEnable()
		{
			_timer.OnFinished += OnTimerFinished;
		}

		public void Initialize(int timerCurrentDuration)
		{
			StartTimer(timerCurrentDuration);
		}

		private void OnDisable()
		{
			_timer.OnFinished -= OnTimerFinished;
		}

		private void StartTimer(int timerCurrentDuration)
		{
			// var startTimerRequest = await _timer.TryStart();
			//
			// if (!startTimerRequest)
			// {
			// 	_timerView.text = "Can't get server time";
			// }
			_timer.Start(timerCurrentDuration);
			Observable
				.Interval(TimeSpan.FromSeconds(1f))
				.Subscribe(_ => _timerView.text = _timer.TimeLeft.ToString("hh\\:mm\\:ss"))
				.AddTo(_disposable);
		}
		
		private void OnTimerFinished()
		{
			_openButton.onClick.AddListener(OpenChest);
			_image.sprite = _sprites[ChestStatus.Ready];
		}

		private void OpenChest()
		{
			_openButton.onClick.RemoveListener(OpenChest);
			_image.sprite = _sprites[ChestStatus.Opened];
			Observable
				.Timer(TimeSpan.FromSeconds(1f))
				.Subscribe(_ => _image.sprite = _sprites[ChestStatus.Closed]);
			_reward.GetReward();
			_timer.Restart();
		}
		
		private enum ChestStatus
		{
			Closed,
			Ready,
			Opened
		}
	}
}