using UnityEngine;

namespace ShootEmUp
{
    public class PlayerDeathObserver : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private GameManager _gameManager;

        private void Awake()
        {
            _player.OnPlayerDied += PlayerDied;
        }

        private void OnDestroy()
        {
            _player.OnPlayerDied -= PlayerDied;
        }

        public void PlayerDied()
        {
            _gameManager.ChangeState(new GameFinishState());
            _gameManager.HandleState();
        }
    }
}