using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class BulletFactory : MonoBehaviour
    {
        [Title("Values")]
        [SerializeField] private int _initialCount = 50;

        [Title("References")]
        [SerializeField] private Pool<Bullet> _pool;
        [SerializeField] private Bullet _prefab;
        [SerializeField] private Transform _worldTransform;
        
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
                bullet = InstantiateBullet();
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

        private Bullet InstantiateBullet()
        {
            return Instantiate(_prefab, _worldTransform);
        }

        private void ConstructBullet(Bullet bullet, BulletConfig config)
        {
            bullet.SetColor(config.color);
            bullet.SetPhysicsLayer((int)config.physicsLayer);
            bullet.SetDamage(config.damage);
            bullet.SetParent(_worldTransform);
        }

        private void FillPool()
        {
            for (var i = 0; i < _initialCount; i++)
            {
                var bullet = InstantiateBullet();
                _pool.AddToPool(bullet);
            }
        }
    }
}