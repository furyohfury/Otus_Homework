using Atomic.Elements;
using Atomic.Entities;
using Game;
using UnityEngine;
using Zenject;

namespace UI
{
	public sealed class CharacterDeathUIObserver : IInitializable, IGameTickable
	{
		private readonly IEntity _character;
		private IFunction<bool> _playerIsDead;
		private readonly GameOverMenuView _gameOverMenuView;

		[Inject]
		public CharacterDeathUIObserver(IEntity character, GameOverMenuView gameOverMenuView)
		{
			_character = character;
			_gameOverMenuView = gameOverMenuView;
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
				_gameOverMenuView.gameObject.SetActive(true);
			}
		}
	}
}