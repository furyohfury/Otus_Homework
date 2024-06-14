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
        private void CheckActiveBulletsInBounds() // todo separate component? Otherwise it's just factory
        {
            var bulletsOutOfBounds = _bulletFactory.ActiveBullets.Where(
                b => !levelBounds.InBounds(b.transform.position));

            foreach(var bullet in bulletsOutOfBounds)
                _bulletFactory.RemoveBullet(bullet);
        }

        public Bullet FireBullet(BulletArgs args)
        {
            return _bulletFactory.GetBullet(args);
        }
        
        private void OnBulletCollision(Bullet bullet, Collision2D collision)
        {            
            bullet.OnCollisionEntered -= this.OnBulletCollision;
            _bulletFactory.RemoveBullet(bullet);
        }
    }
}