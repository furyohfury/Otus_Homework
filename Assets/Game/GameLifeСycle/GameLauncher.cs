using Zenject;

namespace Game
{
	public sealed class GameLauncher : IInitializable // TODO fix
	{
		private readonly GameStateManager _gameStateManager;

		[Inject]
		public GameLauncher(GameStateManager gameStateManager)
		{
			_gameStateManager = gameStateManager;
		}

		public void Initialize()
		{
			_gameStateManager.ChangeState(GameState.Start);
		}
	}
}