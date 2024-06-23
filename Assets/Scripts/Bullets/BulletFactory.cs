using UnityEngine;

namespace ShootEmUp
{
    public sealed class BulletFactory : MonoBehaviour
    {
        [SerializeField] private int _initialCount = 50;
        [SerializeField] private Transform _worldTransform;

        [SerializeField] private Pool<Bullet> _pool;

        private void Awake()
        {
            _pool.FillPool(_initialCount);
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