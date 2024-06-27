using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public sealed class EnemyCycleSpawner : IInitializable, IOnUpdateListener
    {
        [SerializeField] private float _countdown = 1f;
        [SerializeField] private int _maxEnemies = 7;
        [SerializeField] private EnemySystem _enemySystem;

        private float _currentTime = 0f;

        public EnemyCycleSpawner(float countdown, int maxEnemies, EnemySystem enemySystem)
        {
            _countdown = countdown;
            _maxEnemies = maxEnemies;
            _enemySystem = enemySystem;
        }

        void IInitializable.Initialize() => IGameStateListener.Register(this);

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