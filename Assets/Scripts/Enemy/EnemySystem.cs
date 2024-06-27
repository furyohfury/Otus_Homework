using System;
using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemySystem : MonoBehaviour
    {
        public int GetCountOfActive() => _activeEnemies.Count;

        private HashSet<Enemy> _activeEnemies = new();
        [SerializeField] private EnemyFactory _enemyFactory;
        [SerializeField] private BulletSystem _bulletSystem;

        public Enemy GetEnemy()
        {
            var enemy = _enemyFactory.CreateEnemy();
            enemy.OnFire += EnemyFire;
            enemy.OnDied += EnemyDied;
            if (_activeEnemies.Add(enemy))
            {
                return enemy;
            }
            else
            {
                throw new Exception("Trying to add active enemy again");
            }
        }

        public void RemoveEnemy(Enemy enemy)
        {
            if (_activeEnemies.Remove(enemy))
            {
                enemy.OnFire -= EnemyFire;
                enemy.OnDied -= EnemyDied;
                _enemyFactory.RemoveEnemy(enemy);
            }
            else
            {
                throw new Exception("Trying to remove dead enemy");
            }
        }

        private void EnemyDied(Enemy enemy)
        {
            RemoveEnemy(enemy);
        }

        private void EnemyFire(BulletConfig bulletConfig, Vector2 position, Vector2 velocity)
        {
            _bulletSystem.FireBullet(bulletConfig, position, velocity);
        }
    }
}