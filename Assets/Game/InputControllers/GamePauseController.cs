using System;
using Zenject;

namespace Game
{
	public sealed class GamePauseController : IInitializable, IDisposable
	{
		private readonly InputListener _inputListener;
		private readonly GameStateManager _gameStateManager;

		[Inject]
		public GamePauseController(InputListener inputListener, GameStateManager gameStateManager)
		{
			_inputListener = inputListener;
			_gameStateManager = gameStateManager;
		}

		public void Initialize()
		{
			_inputListener.OnCommand += OnPauseCommand;
		}

		private void OnPauseCommand(InputCommand command)
		{
			if (command is not PauseCommand)
			{
				return;
			}

			var currentState = _gameStateManager.State;
			if (currentState is GameState.None)
			{
				return;
			}

			if (currentState is GameState.Resume or GameState.Start)
			{
				_gameStateManager.ChangeState(GameState.Pause);
			}
			else
			{
				_gameStateManager.ChangeState(GameState.Resume);
			}
		}

		public void Dispose()
		{
			_inputListener.OnCommand -= OnPauseCommand;
		}
	}
}