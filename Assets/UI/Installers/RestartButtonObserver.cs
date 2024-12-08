using System;
using Atomic.Entities;
using Game;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI
{
	public sealed class RestartButtonObserver : IInitializable, IDisposable // ujas
	{
		private readonly Button _restartButton;
		private readonly GameObject _startMenuView;
		private readonly GameObject _pauseMenuView;
		private readonly LevelManager _levelManager;
		private SceneEntityWorld _entityWorld;

		[Inject]
		public RestartButtonObserver(Button restartButton, GameObject startMenuView, GameObject pauseMenuView, LevelManager levelManager
			, SceneEntityWorld entityWorld)
		{
			_restartButton = restartButton;
			_startMenuView = startMenuView;
			_pauseMenuView = pauseMenuView;
			_levelManager = levelManager;
			_entityWorld = entityWorld;
		}

		public void Initialize()
		{
			_restartButton.onClick.AddListener(OnRestart);
		}

		private void OnRestart()
		{
			_startMenuView.SetActive(true);
			_pauseMenuView.SetActive(false);
			foreach (var entity in _entityWorld.Entities)
			{
				if (entity is SceneEntity sceneEntity
				    && !sceneEntity.gameObject.activeInHierarchy)
				{
					sceneEntity.gameObject.SetActive(true);
				}
			}
			_levelManager.RestartLevel();
		}

		public void Dispose()
		{
			_restartButton.onClick.RemoveListener(OnRestart);
		}
	}
}