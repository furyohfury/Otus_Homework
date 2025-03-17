using System;
using Game;
using UnityEngine.SceneManagement;
using Zenject;

namespace SceneManagement
{
	public sealed class UnpauseOnSceneSwitchObserver : IInitializable, IDisposable
	{
		private readonly GameStateManager _gameStateManager;

		[Inject]
		public UnpauseOnSceneSwitchObserver(GameStateManager gameStateManager)
		{
			_gameStateManager = gameStateManager;
		}

		void IInitializable.Initialize()
		{
			SceneManager.activeSceneChanged += OnSceneChanged;
		}

		private void OnSceneChanged(Scene arg0, Scene arg1)
		{
			if (_gameStateManager.State is GameState.Pause)
			{
				_gameStateManager.ChangeState(GameState.Resume);
			}
		}

		void IDisposable.Dispose()
		{
			SceneManager.activeSceneChanged -= OnSceneChanged;
		}
	}
}