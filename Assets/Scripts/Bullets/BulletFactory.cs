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
        [SerializeField] protected Transform _worldTransform;

        private void Awake()
        {
            _pool.FillPool();
        }

        public Bullet GetBullet(BulletConfig config, Transform parent)
        {
            Bullet bullet = TakeItemFromPool();
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