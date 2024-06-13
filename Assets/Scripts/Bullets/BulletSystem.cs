using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class BulletSystem : MonoBehaviour
    {
        [SerializeField] private LevelBounds levelBounds;
        [SerializeField] private BulletFactory _bulletFactory;
        
        private void FixedUpdate()
        {
            CheckActiveBulletsInBounds();
        }
        private void CheckActiveBulletsInBounds()
        {
            var bulletsOutOfBounds = _bulletFactory.ActiveBullets.Where(
                b => !levelBounds.InBounds(b.transform.position));

            foreach(var bullet in bulletsOutOfBounds)
                _bulletFactory.RemoveBullet(bullet);
        }

        public void FireBullet(BulletArgs args)
        {
            Bullet bullet = _bulletFactory.GetBullet(args);
        }
        
        private void OnBulletCollision(Bullet bullet, Collision2D collision)
        {
            BulletUtils.DealDamage(bullet, collision.gameObject);
            bullet.OnCollisionEntered -= this.OnBulletCollision;
            _bulletFactory.RemoveBullet(bullet);
        }
    }
}