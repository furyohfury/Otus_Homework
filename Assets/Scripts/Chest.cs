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
	public sealed class Chest : MonoBehaviour
	{
		[SerializeField]
		private ChestData _chestData;
		[SerializeField]
		private ChestView _chestView;

		private CompositeDisposable _disposable;

		public void Construct(ChestData chestData)
		{
			_chestData = chestData;
			_chestData.Initialize();
			_chestData.Timer.OnFinished += OnTimerFinished;
			StartTimerView();
		}

		private void StartTimerView()
		{
			Observable
				.Interval(TimeSpan.FromSeconds(1f))
				.Subscribe(_ => _chestView.SetTimerText(_chestData.Timer.TimeLeft.ToString("hh\\:mm\\:ss")))
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
			Reward.GetReward();
			_timer.Restart();
		}
	}
}