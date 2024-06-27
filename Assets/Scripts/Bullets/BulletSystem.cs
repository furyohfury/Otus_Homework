using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class BulletSystem : MonoBehaviour, IGamePauseListener, IGameResumeListener, IGameFinishListener
    {
        public HashSet<Bullet> ActiveBullets { get; private set; } = new();

        [SerializeField] private BulletFactory _bulletFactory;
        private Dictionary<Bullet, Vector2> _velocities;

        private void Awake()
        {
            IGameStateListener.Register(this);
        }

        public Bullet FireBullet(BulletConfig config, Vector2 position, Vector2 velocity)
        {
            Bullet bullet = _bulletFactory.CreateBullet(config);
            bullet.SetPosition(position);
            bullet.SetVelocity(velocity);
            bullet.OnCollisionEntered += OnBulletCollision;
            if (ActiveBullets.Add(bullet))
            {
                return bullet;
            }
            else
            {
                throw new Exception("Trying to add active bullet again");
            }
        }

        public void RemoveBullet(Bullet bullet)
        {
            if (ActiveBullets.Remove(bullet))
            {
                _bulletFactory.RemoveBullet(bullet);
                bullet.OnCollisionEntered -= OnBulletCollision;
            }
            else
            {
                throw new Exception("Trying to remove already inactive bullet");
            }
        }

        private void OnBulletCollision(Bullet bullet, Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent(out HitPointsComponent hpComponent))
            {
                hpComponent.TakeDamage(bullet.Damage);
            }
            RemoveBullet(bullet);
        }

        void IGamePauseListener.PauseGame()
        {
            _velocities = ActiveBullets.ToDictionary(bullet => bullet, bullet => bullet.Velocity);
            foreach (var bullet in ActiveBullets)
            {
                bullet.SetVelocity(Vector2.zero);
            }
        }

        void IGameResumeListener.ResumeGame()
        {
            foreach (var bullet in ActiveBullets)
            {
                bullet.SetVelocity(_velocities[bullet]);
            }
        }

        void IGameFinishListener.FinishGame()
        {
            foreach (var bullet in ActiveBullets)
            {
                bullet.SetVelocity(Vector2.zero);
            }
        }
    }
}