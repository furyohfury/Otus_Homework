using System;
using System.Collections.Generic;
using System.Linq;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public sealed class BulletSystem : IInitializable, IGamePauseListener, IGameResumeListener, IGameFinishListener
    {
        public HashSet<Bullet> ActiveBullets { get; private set; } = new();
        private readonly BulletFactory _bulletFactory;
        private Dictionary<Bullet, Vector2> _velocities;

        private Dictionary<Bullet, IDisposable> _disposables = new();

        [Inject]
        public BulletSystem(BulletFactory bulletFactory)
        {
            _bulletFactory = bulletFactory;
        }

        void IInitializable.Initialize() => IGameStateListener.Register(this);

        public Bullet FireBullet(BulletConfig config, Vector2 position, Vector2 velocity)
        {
            Bullet bullet = _bulletFactory.CreateBullet(config);
            bullet.SetPosition(position);
            bullet.SetVelocity(velocity);

            var collisionDisposable = bullet.OnCollisionEnter2DAsObservable()
                .Subscribe(col => OnBulletCollision(bullet, col));
            _disposables.Add(bullet, collisionDisposable);


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
                //_disposables[bullet].Dispose();
                //_disposables.Remove(bullet);
            }
            else
            {
                throw new Exception("Trying to remove already inactive bullet");
            }
        }

        private void OnBulletCollision(Bullet bullet, Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent(out IHitPoints hpComponent))
            {
                hpComponent.HitPointsComponent.TakeDamage(bullet.Damage);
                _disposables[bullet].Dispose();
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
                _disposables[bullet].Dispose();
            }
        }
    }
}