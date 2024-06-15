using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class BulletFactory : MonoBehaviour
    {
        [SerializeField]
        private int initialCount = 50;
        
        [SerializeField] private Transform container;
        [SerializeField] private Bullet prefab;
        [SerializeField] private Transform worldTransform;

        private readonly Queue<Bullet> m_bulletPool = new();
        public HashSet<Bullet> ActiveBullets { get; private set; } = new HashSet<Bullet>();
        
        private void Awake()
        {
            for (var i = 0; i < this.initialCount; i++)
            {
                var bullet = Instantiate(this.prefab, this.container);
                this.m_bulletPool.Enqueue(bullet);
            }
        }

        public Bullet GetBullet(BulletConfig config)
        {
            if (this.m_bulletPool.TryDequeue(out var bullet))
            {
                bullet.transform.SetParent(this.worldTransform);
            }
            else
            {
                bullet = Instantiate(this.prefab, this.worldTransform);
            }
            ConstructBullet(bullet, config);
            ActiveBullets.Add(bullet);
            return bullet;
        }

        public void RemoveBullet(Bullet bullet)
        {
            if (this.ActiveBullets.Remove(bullet))
            {
                bullet.transform.SetParent(this.container);
                this.m_bulletPool.Enqueue(bullet);
            }
        }       

        private void ConstructBullet(Bullet bullet, BulletConfig config)
        {
            bullet.SetColor(config.color);
            bullet.SetPhysicsLayer((int)config.physicsLayer);
            bullet.SetDamage(config.damage);
        }
    }
}