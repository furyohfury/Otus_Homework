using System.Collections;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemySystem : MonoBehaviour
    {
        [SerializeField] private EnemyFactory _enemyFactory;
        [SerializeField] private BulletSystem _bulletSystem;

        private void OnEnable()
        {
            _enemyCycleSpawner.OnSpawnEnemy += SpawnEnemy;
        }

        private void OnDisable()
        {
            _enemyCycleSpawner.OnSpawnEnemy -= SpawnEnemy;
        }        

        private void SpawnEnemy()
        {
            var enemy = _enemyFactory.CreateEnemy();
            enemy.OnFire += EnemyFire;
            enemy.OnDied += EnemyDied;
        }

        private void EnemyDied(Enemy enemy)
        {
            enemy.OnFire -= EnemyFire;
            enemy.OnDied -= EnemyDied;
            _enemyFactory.RemoveEnemy(enemy);
        }

        private void EnemyFire(BulletConfig bulletConfig, Vector2 position, Vector2 velocity)
        {
            _bulletSystem.FireBullet(bulletConfig, position, velocity);
        }
    }
}