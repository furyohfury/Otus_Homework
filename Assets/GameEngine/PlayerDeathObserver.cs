using Atomic.Extensions;
using Atomic.Objects;
using Zenject;

namespace GameEngine
{
    public sealed class PlayerDeathObserver : IInitializable
    {
        private readonly AtomicObject _player;
        private readonly GameManager _gameManager;

        public PlayerDeathObserver(AtomicObject player, GameManager gameManager)
        {
            _player = player;
            _gameManager = gameManager;
        }

        void IInitializable.Initialize()
        {
            _player.GetObservable<bool>(LifeAPI.IS_ALIVE).Subscribe(_ => _gameManager.GameOver());
        }
    }
}