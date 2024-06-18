using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public class EnemyFactory : MonoBehaviour
    {
        [Title("Values")]
        [SerializeField] private int _initialCount = 7;
        [Title("References")]
        [SerializeField] private Pool<Enemy> _pool;
        [SerializeField] private EnemyPositions _enemyPositions;        
        [SerializeField] private Transform _target;        
        [SerializeField] private Transform _worldTransform;        

        private void Awake()
        {
            _pool.FillPool(_initialCount);
        }
        public Enemy CreateEnemy()
        {
            Enemy enemy = pool.TryTakeItemFromPool();
            ConstructEnemy(enemy);
            _activeEnemies.Add(enemy);
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
            _activeEnemies.Remove(enemy);
            _pool.AddToPool(enemy);
        }

        private void FillPool()
        {
            for (int i = 0; i < _initialCount; i++)
            {
                var enemy = CreateEnemy();
                _pool.AddToPool(enemy);
            }
        }
    }
}