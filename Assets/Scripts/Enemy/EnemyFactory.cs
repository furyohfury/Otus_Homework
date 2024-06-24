using UnityEngine;

namespace ShootEmUp
{
    public class EnemyFactory : MonoBehaviour
    {
        [SerializeField] private int _initialCount = 7;

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