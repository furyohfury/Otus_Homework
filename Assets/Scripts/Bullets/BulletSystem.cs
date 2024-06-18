using System;
using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class BulletSystem : MonoBehaviour
    {        
        [SerializeField] private BulletFactory _bulletFactory;

        public HashSet<Bullet> ActiveBullets { get; private set; } = new();

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
            }
            else
            {
                throw new Exception("Trying to remove already inactive bullet");
            }            
        }

        private void OnBulletCollision(Bullet bullet, Collision2D collision) // separate class?
        {
            if (collision.gameObject.TryGetComponent(out HitPointsComponent hpComponent))
            {
                hpComponent.TakeDamage(bullet.Damage);
            }
            bullet.OnCollisionEntered -= OnBulletCollision;
            RemoveBullet(bullet);
        }
    }
}