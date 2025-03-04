using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;
using Zenject;

namespace Game
{
	public sealed class CharacterDeathObserver : IInitializable, IGameTickable
	{
		private readonly IEntity _character;
		private IFunction<bool> _playerIsDead;
		private readonly GameStateManager _gameStateManager;

		[Inject]
		public CharacterDeathObserver(IEntity character, GameStateManager gameStateManager)
		{
			_character = character;
			_gameStateManager = gameStateManager;
		}

		public void Initialize()
		{
			if (_character.TryGetIsDead(out BaseFunction<bool> isDead) == false)
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