using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyCycleSpawner : MonoBehaviour, IOnUpdateListener
    {
        [SerializeField] private int _countdown = 1;
        [SerializeField] private int _maxEnemies = 7;
        [SerializeField] private EnemySystem _enemySystem;
        private float _currentTime = 0f;

        private void Awake()
        {
            IGameStateListener.Register(this);
        }

        void IOnUpdateListener.OnUpdate(float deltaTime)
        {
            if (_currentTime <= 0 && _enemySystem.GetCountOfActive() < _maxEnemies)
            {
                _currentTime = _countdown;
                _enemySystem.GetEnemy();

            }
            else
            {
                _currentTime -= deltaTime;
            }
        }
    }
}