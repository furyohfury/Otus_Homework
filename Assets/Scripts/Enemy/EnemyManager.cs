using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyManager : MonoBehaviour
    {
        [SerializeField] private EnemyFactory _enemyFactory;
        [SerializeField] private BulletSystem _bulletSystem;
        [SerializeField] private int _maxEnemies = 7;

        private IEnumerator Start()
        {
            while (true)
            {
                yield return new WaitForSeconds(1);
                if (_enemyFactory.GetCountOfActive() < _maxEnemies)
                {
                    var enemy = _enemyFactory.CreateEnemy();
                    enemy.OnFire += EnemyFire;
                    enemy.OnDied += () => EnemyDied(enemy);
                }
            }
        }

        private void EnemyDied(Enemy enemy)
        {
            enemy.OnFire -= EnemyFire;
            _enemyFactory.RemoveEnemy(enemy);
        }

        private void EnemyFire(BulletConfig bulletConfig, Vector2 position, Vector2 velocity)
        {
            _bulletSystem.FireBullet(bulletConfig, position, velocity);
        }
    }
}