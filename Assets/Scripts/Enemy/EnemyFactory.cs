using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public class EnemyFactory : MonoBehaviour
    {
        [SerializeField] private Enemy _prefab;
        [SerializeField] private Pool<Enemy> _pool;
        [SerializeField] private EnemyPositions enemyPositions;
        [SerializeField] private HashSet<Enemy> _activeEnemies = new();
        [SerializeField] private Transform _target;
        [SerializeField] private int _initialCount = 7;
        [SerializeField] private Transform _worldTransform;

        public int GetCountOfActive() => _activeEnemies.Count;

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
            var spawnPosition = enemyPositions.GetRandomSpawnPosition();
            enemy.SetPosition(spawnPosition);
            var attackPosition = enemyPositions.GetRandomAttackPosition();
            enemy.SetTarget(_target);
            enemy.SetDestination(attackPosition);            
        }

        public void RemoveEnemy(Enemy enemy)
        {
            _activeEnemies.Remove(enemy);
            _pool.AddToPool(enemy);
        }
    }
}