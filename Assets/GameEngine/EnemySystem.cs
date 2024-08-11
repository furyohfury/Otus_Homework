using System;
using System.Collections.Generic;
using Atomic.Objects;
using Cysharp.Threading.Tasks;
using Object = UnityEngine.Object;

namespace GameEngine
{
    public sealed class EnemySystem
    {
        private readonly HashSet<AtomicEntity> _enemies = new();
        private readonly SpawnerOnCD _enemySpawner;
        private readonly float _enemyDestroyDelay = 2f;

        public EnemySystem(SpawnerOnCD enemySpawner, float enemyDestroyDelay)
        {
            _enemySpawner = enemySpawner;
            _enemyDestroyDelay = enemyDestroyDelay;
            _enemySpawner.OnSpawnedEvent.Subscribe(EnemySpawned);
        }

        private void EnemySpawned(AtomicEntity entity)
        {
            if (!_enemies.Add(entity))
            {
                throw new Exception($"Enemy {entity.gameObject.name} has been already added");
            }
        }

        public async UniTask EnemyKilled(AtomicEntity enemy)
        {
            if (!_enemies.Remove(enemy))
            {
                throw new Exception($"Enemy {enemy.gameObject.name} has been already deleted");
            }

            await UniTask.Delay(TimeSpan.FromSeconds(_enemyDestroyDelay));
            Object.Destroy(enemy.gameObject);
        }
    }
}