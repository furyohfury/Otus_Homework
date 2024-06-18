using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public class EnemyFactory : MonoBehaviour
    {
        [Title("Values")]
        [SerializeField] private int _initialCount = 7;
        [Title("References")]
        [SerializeField] private Enemy _prefab;
        [SerializeField] private Pool<Enemy> _pool;
        [SerializeField] private EnemyPositions _enemyPositions;        
        [SerializeField] private Transform _target;        
        [SerializeField] private Transform _worldTransform;

        private HashSet<Enemy> _activeEnemies = new();
        public int GetCountOfActive() => _activeEnemies.Count;

        private void Awake()
        {
            FillPool();
        }
        public Enemy CreateEnemy()
        {
            Enemy enemy;
            if (_pool.TryTakeItemFromPool(out Enemy pooledEnemy))
            {
                enemy = pooledEnemy;
            }
            else
            {
                enemy = Instantiate(_prefab);
            }
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