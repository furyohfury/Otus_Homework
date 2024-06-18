using UnityEngine;

namespace ShootEmUp
{
    public class PlayerDeathObserver : MonoBehaviour
    {
        [SerializeField] private HitPointsComponent _hitPointsComponent;
        [SerializeField] private GameManager _gameManager;

        private void OnEnable()
        {
            _hitPointsComponent.OnHPEnded += PlayerDied;
        }
        private void OnDisable()
        {
            _hitPointsComponent.OnHPEnded -= PlayerDied;
        }

        public void PlayerDied()
        {
            _gameManager.FinishGame();
        }
    }
}