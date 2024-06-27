using Zenject;

namespace ShootEmUp
{
    public sealed class PlayerDeathObserver : IInitializable
    {
        private readonly Player _player;
        private readonly GameManager _gameManager;

        [Inject]
        public PlayerDeathObserver(Player player, GameManager gameManager)
        {
            _player = player;
            _gameManager = gameManager;
        }

        public void Initialize() => _player.OnPlayerDied += PlayerDied;

        private void PlayerDied()
        {
            _player.OnPlayerDied -= PlayerDied;
            _gameManager.ChangeState(new GameFinishState());
            _gameManager.HandleState();
        }
    }
}