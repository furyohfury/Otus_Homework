using UnityEngine;

namespace ShootEmUp
{
    public class PlayerDeathObserver : MonoBehaviour // redo w/ DI next homework
    {
        [SerializeField] private HitPointsComponent _hitPointsComponent;
        [SerializeField] private GameManager _gameManager;

        private void OnEnable()
        {
            _hitPointsComponent.OnHPEnded += OnCharacterDeath;
        }
        private void OnDisable()
        {
            _hitPointsComponent.OnHPEnded -= OnCharacterDeath;
        }

        public void OnCharacterDeath()
        {
            _gameManager.FinishGame();
        }
    }
}