using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    [System.Serializable]
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

        public Bullet GetBullet(BulletArgs args)
        {
            if (this.m_bulletPool.TryDequeue(out var bullet))
            {
                bullet.transform.SetParent(this.worldTransform);
            }
            else
            {
                bullet = Instantiate(this.prefab, this.worldTransform);
            }
            ConstructBullet(bullet, args);
            if (ActiveBullets.Add(bullet))
            {
                bullet.OnCollisionEntered += OnBulletCollision;
            }
            return bullet;
        }

        public void OnBulletCollision(Bullet bullet, Collision2D collision)
        {
            bullet.OnCollisionEntered -= OnBulletCollision;
            RemoveBullet(bullet);
        }

        public void RemoveBullet(Bullet bullet)
        {
            if (this.ActiveBullets.Remove(bullet))
            {
                bullet.transform.SetParent(this.container);
                this.m_bulletPool.Enqueue(bullet);
            }
        }       

        private void ConstructBullet(Bullet bullet, BulletArgs args)
        {
            bullet.SetPosition(args.position);
            bullet.SetColor(args.color);
            bullet.SetPhysicsLayer(args.physicsLayer);
            bullet.SetDamage(args.damage);
            bullet.SetIsPlayer(args.isPlayer);
            bullet.SetVelocity(args.velocity);
        }
    }
}