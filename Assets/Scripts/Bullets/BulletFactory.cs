using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class BulletFactory : MonoBehaviour
    {
        [SerializeField] private Pool<Bullet> _pool;

        [SerializeField] private Bullet _prefab;
        [SerializeField] private Transform worldTransform;
        [SerializeField] private int _initialCount = 50;
        public HashSet<Bullet> ActiveBullets { get; private set; } = new();

        private void Awake()
        {
            FillPool();
        }
        public Bullet GetBullet(BulletConfig config)
        {
            Bullet bullet;
            if (_pool.TryTakeItemFromPool(out Bullet poolBullet))
            {
                bullet = poolBullet;
            }
            else
            {
                bullet = CreateBullet();
            }            
            ConstructBullet(bullet, config);
            ActiveBullets.Add(bullet);
            return bullet;
        }

        public void RemoveBullet(Bullet bullet)
        {
            if (ActiveBullets.Remove(bullet))
            {
                _pool.AddToPool(bullet);
            }
        }

        private Bullet CreateBullet()
        {
            return Instantiate(_prefab, worldTransform);
        }

        private void ConstructBullet(Bullet bullet, BulletConfig config)
        {
            bullet.SetColor(config.color);
            bullet.SetPhysicsLayer((int)config.physicsLayer);
            bullet.SetDamage(config.damage);
            bullet.SetParent(worldTransform);
        }

        private void FillPool()
        {
            for(var i = 0; i < _initialCount; i++)
            {
                var bullet = CreateBullet();
                _pool.AddToPool(bullet);
            }
        }
    }
}