using System;
using Atomic.Entities;
using Zenject;

namespace Game
{
	public sealed class EntityWorldStateController : IInitializable, IDisposable
	{
		private readonly IEntityWorld _entityWorld;
		private readonly GameStateManager _gameStateManager;

		[Inject]
		public EntityWorldStateController(IEntityWorld entityWorld, GameStateManager gameStateManager)
		{
			_entityWorld = entityWorld;
			_gameStateManager = gameStateManager;
		}


		public void Initialize()
		{
			_gameStateManager.OnStateChanged += OnStateChanged;
		}

		private void OnStateChanged(GameState state)
		{
			if (state is GameState.Pause or GameState.Finish)
			{
				_entityWorld.DisableEntities();
			}
			else
			{
				_entityWorld.EnableEntities();
			}
		}

		public void Dispose()
		{
			_gameStateManager.OnStateChanged -= OnStateChanged;
			_entityWorld.DisposeEntities();
		}
	}
}