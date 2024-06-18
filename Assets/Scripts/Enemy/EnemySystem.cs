using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemySystem : MonoBehaviour
    {
        [SerializeField] private EnemyFactory _enemyFactory;
        [SerializeField] private BulletSystem _bulletSystem;

        private HashSet<Enemy> _activeEnemies = new();
        public int GetCountOfActive() => _activeEnemies.Count;

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
            enemy.OnFire -= EnemyFire;
            enemy.OnDied -= EnemyDied;
            _enemyFactory.RemoveEnemy(enemy);
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