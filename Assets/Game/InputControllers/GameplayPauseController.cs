using System;
using UnityEngine;
using Zenject;

namespace Game
{
	public sealed class GameplayPauseController : IInitializable, IDisposable
	{
		private readonly InputReader _inputReader;
		private readonly GameStateManager _gameStateManager;

		[Inject]
		public GameplayPauseController(InputReader inputReader, GameStateManager gameStateManager)
		{
			_inputReader = inputReader;
			_gameStateManager = gameStateManager;
		}

		public void Initialize()
		{
			_inputReader.OnPaused += OnPause;
		}

		private void OnPause()
		{
			var currentState = _gameStateManager.State;
			if (currentState is GameState.None)
			{
				return;
			}

			if (currentState is GameState.Resume or GameState.Start)
			{
				_gameStateManager.ChangeState(GameState.Pause);
				Debug.Log("Game paused");
			}
			else
			{
				_gameStateManager.ChangeState(GameState.Resume);
				Debug.Log("Game resumed");
			}
		}

		public void Dispose()
		{
			_inputReader.OnPaused -= OnPause;
		}
	}
}