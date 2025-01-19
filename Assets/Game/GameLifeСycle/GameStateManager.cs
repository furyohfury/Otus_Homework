using System;

namespace Game
{
	public sealed class GameStateManager
	{
		public event Action<GameState> OnStateChanged;

		public GameState State => _state;

		private GameState _state = GameState.None;

		public void ChangeState(GameState state)
		{
			if (_state == state)
			{
				return;
			}

			_state = state;
			OnStateChanged?.Invoke(state);
		}
	}

	public enum GameState
	{
		None
		, Start
		, Pause
		, Resume
		, Finish
	}
}