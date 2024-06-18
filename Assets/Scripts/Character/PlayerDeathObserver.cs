using UnityEngine;

namespace ShootEmUp
{
    public class PlayerDeathObserver : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private GameManager _gameManager;

        private void OnEnable()
        {
            _player.OnPlayerDied += PlayerDied;
        }
        private void OnDisable()
        {
            _player.OnPlayerDied -= PlayerDied;
        }

        public void PlayerDied()
        {
            _gameManager.FinishGame();
        }
    }
}