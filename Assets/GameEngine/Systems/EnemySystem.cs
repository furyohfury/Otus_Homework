using System;
using System.Collections.Generic;
using Atomic.Elements;
using Atomic.Extensions;
using Atomic.Objects;
using Cysharp.Threading.Tasks;
using Zenject;
using Object = UnityEngine.Object;

namespace GameEngine
{
    public sealed class EnemySystem : IInitializable
    {
        public AtomicEvent OnEnemyKilledEvent = new();
        private readonly HashSet<AtomicEntity> _enemies = new();
        private readonly SpawnerOnCD _enemySpawner;
        private readonly float _enemyDestroyDelay = 2f;

        [Inject]
        public EnemySystem(SpawnerOnCD enemySpawner, float enemyDestroyDelay)
        {
            _enemySpawner = enemySpawner;
            _enemyDestroyDelay = enemyDestroyDelay;
        }
        void IInitializable.Initialize()
        {
            _enemySpawner.OnSpawnedEvent.Subscribe(EnemySpawned);
            _enemySpawner.Enable();
        }

        private void EnemySpawned(AtomicEntity entity)
        {
            if (!_enemies.Add(entity))
            {
                throw new Exception($"Enemy {entity.gameObject.name} has been already added");
            }
            if (entity.TryGetObservable<bool>(LifeAPI.IS_ALIVE, out var obs))
            {
                obs.Subscribe(isAlive =>
                {
                    if (!isAlive)
                    {
                        EnemyKilled(entity).Forget();
                    }
                });
            }
        }

        public async UniTask EnemyKilled(AtomicEntity enemy)
        {
            if (!_enemies.Remove(enemy))
            {
                throw new Exception($"Enemy {enemy.gameObject.name} has been already deleted");
            }
            OnEnemyKilledEvent.Invoke();
            await UniTask.Delay(TimeSpan.FromSeconds(_enemyDestroyDelay));
            Object.DestroyImmediate(enemy.gameObject);
        }
    }
}