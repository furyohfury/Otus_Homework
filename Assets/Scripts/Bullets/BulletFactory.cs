using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public sealed class BulletFactory
    {
        private readonly Transform _worldTransform;
        private readonly BulletPool _pool;

        [Inject]
        public BulletFactory(Transform worldTransform, Transform poolParent, Bullet prefab, int initialCount)
        {
            _worldTransform = worldTransform;
            _pool = new BulletPool(poolParent, prefab);
            _pool.FillPool(initialCount);
        }

        public Bullet CreateBullet(BulletConfig config)
        {
            Bullet bullet = _pool.TakeItemFromPool();
            ConstructBullet(bullet, config);
            return bullet;
        }

        public void RemoveBullet(Bullet bullet) => _pool.AddToPool(bullet);

        private void ConstructBullet(Bullet bullet, BulletConfig config)
        {
            bullet.SetColor(config.color);
            bullet.SetPhysicsLayer((int)config.physicsLayer);
            bullet.SetDamage(config.damage);
            bullet.SetParent(_worldTransform);
        }
    }
}