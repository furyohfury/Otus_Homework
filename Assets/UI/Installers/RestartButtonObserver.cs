using System;
using Game;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI
{
	public sealed class RestartButtonObserver : IInitializable, IDisposable
	{
		private readonly Button _restartButton;
		private readonly GameObject _startMenuView;
		private readonly GameObject _pauseMenuView;
		private readonly LevelManager _levelManager;

		[Inject]
		public RestartButtonObserver(Button restartButton, GameObject startMenuView, GameObject pauseMenuView, LevelManager levelManager)
		{
			_restartButton = restartButton;
			_startMenuView = startMenuView;
			_pauseMenuView = pauseMenuView;
			_levelManager = levelManager;
		}

		public void Initialize()
		{
			_restartButton.onClick.AddListener(OnRestart);
		}

		private void OnRestart()
		{
			_startMenuView.SetActive(true);
			_pauseMenuView.SetActive(false);
			_levelManager.RestartLevel();
		}

		public void Dispose()
		{
			_restartButton.onClick.RemoveListener(OnRestart);
		}
	}
}