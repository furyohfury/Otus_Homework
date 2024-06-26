using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public class EnemyFactory
    {
        private readonly EnemyPool _pool;
        private readonly EnemyPositions _enemyPositions;
        private readonly Transform _target;
        private readonly Transform _worldTransform;

        [Inject]
        public EnemyFactory(int initialCount, EnemyPositions enemyPositions, Transform target, Transform worldTransform, Transform poolParent, Enemy prefab)
        {
            _pool = new EnemyPool(poolParent, prefab);
            _pool.FillPool(initialCount);
            _enemyPositions = enemyPositions;
            _target = target;
            _worldTransform = worldTransform;
        }

        public Enemy CreateEnemy()
        {
            Enemy enemy = _pool.TakeItemFromPool();
            ConstructEnemy(enemy);
            return enemy;
        }

        public void ConstructEnemy(Enemy enemy)
        {
            enemy.SetParent(_worldTransform);
            var spawnPosition = _enemyPositions.GetRandomSpawnPosition();
            enemy.SetPosition(spawnPosition);
            var attackPosition = _enemyPositions.GetRandomAttackPosition();
            enemy.SetTarget(_target);
            enemy.SetDestination(attackPosition);
        }

        public void RemoveEnemy(Enemy enemy)
        {
            _pool.AddToPool(enemy);
        }
    }
}