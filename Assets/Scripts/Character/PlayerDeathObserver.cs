using UnityEngine;

namespace ShootEmUp
{
    public class PlayerDeathObserver : MonoBehaviour // redo w/ DI next homework
    {
        [SerializeField] private HitPointsComponent _hitPointsComponent;
        [SerializeField] private GameManager _gameManager;

        private void OnEnable()
        {
            _hitPointsComponent.OnHPEnded += this.OnCharacterDeath;
        }
        private void OnDisable()
        {
            _hitPointsComponent.OnHPEnded -= this.OnCharacterDeath;
        }

        public void OnCharacterDeath()
        {
            _gameManager.FinishGame();
        }
    }
}