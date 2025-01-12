using Atomic.Elements;
using Atomic.Entities;
using Game;
using UnityEngine;
using Zenject;

namespace UI
{
	public sealed class CharacterDeathObserver : IInitializable, IGameTickable
	{
		private readonly IEntity _character;
		private IFunction<bool> _playerIsDead;
		private readonly GameObject _gameOverCanvas;

		[Inject]
		public CharacterDeathObserver(IEntity character, GameObject gameOverCanvas)
		{
			_character = character;
			_gameOverCanvas = gameOverCanvas;
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
				_character.Disable();
				_gameOverCanvas.SetActive(true);
			}
		}
	}
}