using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public sealed class EnemySystem
    {
        private readonly EnemyFactory _enemyFactory;
        private readonly BulletSystem _bulletSystem;

        private readonly HashSet<Enemy> _activeEnemies = new();
        public int GetCountOfActive() => _activeEnemies.Count;

        [Inject]
        public EnemySystem(EnemyFactory enemyFactory, BulletSystem bulletSystem)
        {
            _enemyFactory = enemyFactory;
            _bulletSystem = bulletSystem;
        }

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