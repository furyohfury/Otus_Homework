using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public sealed class BulletSystem
    {
        private readonly BulletFactory _bulletFactory;

        public HashSet<Bullet> ActiveBullets { get; private set; } = new();

        [Inject]
        public BulletSystem(BulletFactory bulletFactory)
        {
            _bulletFactory = bulletFactory;
        }

        public Bullet FireBullet(BulletConfig config, Vector2 position, Vector2 velocity)
        {
            Bullet bullet = _bulletFactory.CreateBullet(config);
            bullet.SetPosition(position);
            bullet.SetVelocity(velocity);
            bullet.OnCollisionEntered += OnBulletCollision;
            if (ActiveBullets.Add(bullet))
            {
                return bullet;
            }
            else
            {
                throw new Exception("Trying to add active bullet again");
            }
        }

        public void RemoveBullet(Bullet bullet)
        {
            if (ActiveBullets.Remove(bullet))
            {
                _bulletFactory.RemoveBullet(bullet);
                bullet.OnCollisionEntered -= OnBulletCollision;
            }
            else
            {
                throw new Exception("Trying to remove already inactive bullet");
            }
        }

        private void OnBulletCollision(Bullet bullet, Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent(out IHitPoints hpComponent))
            {
                hpComponent.HitPointsComponent.TakeDamage(bullet.Damage);
            }            
            RemoveBullet(bullet);
        }
    }
}