using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;
using Zenject;

namespace Game
{
	public sealed class CharacterDeathObserver : IInitializable, IGameTickable
	{
		private readonly PlayerService _playerService;
		private IFunction<bool> _playerIsDead;
		private readonly GameStateManager _gameStateManager;

		[Inject]
		public CharacterDeathObserver(GameStateManager gameStateManager, PlayerService playerService)
		{
			_gameStateManager = gameStateManager;
			_playerService = playerService;
		}

		public void Initialize()
		{
			if (_playerService.Player.TryGetIsDead(out BaseFunction<bool> isDead) == false)
			{
				Debug.LogError("Cant find isDead on player");
				return;
			}

			_playerIsDead = isDead;
		}

		public void Tick(float deltaTime)
		{
			if (_playerIsDead.Invoke())
			{
				_gameStateManager.ChangeState(GameState.Pause);
			}
		}
	}
}