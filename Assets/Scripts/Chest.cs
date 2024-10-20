﻿using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Newtonsoft.Json;
using Sirenix.OdinInspector;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace RealTime
{
	public sealed class Chest : SerializedMonoBehaviour
	{
		[field: SerializeReference]
		public IReward[] Rewards { get; private set; }

		[field: SerializeField]
		public ChestType ChestType { get; private set; }

		[field: SerializeField]
		public ChestTimer Timer { get; private set; }

		[SerializeField]
		private TMP_Text _timerView;
		[SerializeField]
		private Button _openButton;
		[SerializeField]
		private Image _image;
		[SerializeField]
		private Dictionary<ChestStatus, Sprite> _sprites;

		private CompositeDisposable _disposable = new();

		public void Construct(IReward[] rewards, ChestType type, ChestTimer timer, DiContainer diContainer)
		{
			Rewards = rewards;
			ChestType = type;
			Timer = timer;

			foreach (var reward in Rewards)
			{
				diContainer.Inject(reward);
			}
		}

		private void Start()
		{
			Timer.OnFinished += OnTimerFinished;
			Timer.Initialize();
			StartTimerView();
		}

		private void StartTimerView()
		{
			Observable
				.Interval(TimeSpan.FromSeconds(1f))
				.Subscribe(_ => _timerView.text = Timer.TimeLeft.ToString("hh\\:mm\\:ss"))
				.AddTo(_disposable);
		}

		private void OnTimerFinished()
		{
			_openButton.onClick.AddListener(OpenChest);
			_disposable.Clear();
			_timerView.text = "Ready to open!";
			_image.sprite = _sprites[ChestStatus.Ready];
		}

		private void OpenChest()
		{
			_openButton.onClick.RemoveListener(OpenChest);
			_image.sprite = _sprites[ChestStatus.Opened];
			Observable
				.Timer(TimeSpan.FromSeconds(1f))
				.Subscribe(_ => _image.sprite = _sprites[ChestStatus.Closed]);

			foreach (var reward in Rewards)
			{
				reward.GetReward();
			}

			Timer.Restart();
			StartTimerView();
		}

		private enum ChestStatus
		{
			Closed,
			Ready,
			Opened
		}
	}
}