using System;
using Game;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI
{
	public sealed class PlayButtonObserver : IInitializable, IDisposable
	{
		private readonly Button _playButton;
		private readonly LevelManager _levelManager;
		private readonly GameObject _startMenuView;

		[Inject]
		public PlayButtonObserver(Button playButton, LevelManager levelManager, GameObject startMenuView)
		{
			_playButton = playButton;
			_levelManager = levelManager;
			_startMenuView = startMenuView;
		}

		public void Initialize()
		{
			_playButton.onClick.AddListener(OnPlayButtonPressed);
		}

		private void OnPlayButtonPressed()
		{
			_startMenuView.SetActive(false);
			_levelManager.StartLevel();
		}

		public void Dispose()
		{
			_playButton.onClick.RemoveListener(OnPlayButtonPressed);
		}
	}
}