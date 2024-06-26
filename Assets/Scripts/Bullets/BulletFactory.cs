using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public sealed class BulletFactory
    {
        private readonly int _initialCount = 50;
        private readonly Transform _worldTransform;
        private readonly Bullet _prefab;

        private readonly BulletPool _pool;

        [Inject]
        public BulletFactory(Transform worldTransform, Transform poolParent, Bullet prefab, int initialCount)
        {
            _worldTransform = worldTransform;
            _prefab = prefab;

            _pool = new BulletPool(poolParent, _prefab);
            _pool.FillPool(_initialCount);
            _initialCount = initialCount;
        }

        public Bullet CreateBullet(BulletConfig config)
        {
            Bullet bullet = _pool.TakeItemFromPool();
            ConstructBullet(bullet, config);
            return bullet;
        }

        public void RemoveBullet(Bullet bullet)
        {
            _pool.AddToPool(bullet);
        }

        private void ConstructBullet(Bullet bullet, BulletConfig config)
        {
            bullet.SetColor(config.color);
            bullet.SetPhysicsLayer((int)config.physicsLayer);
            bullet.SetDamage(config.damage);
            bullet.SetParent(_worldTransform);
        }
    }
}