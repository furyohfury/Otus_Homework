using System.Linq;
using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public sealed class BulletsOutOfBoundsObserver : IInitializable, IOnFixedUpdateListener
    {
        [SerializeField] private LevelBounds _levelBounds;
        [SerializeField] private BulletSystem _bulletSystem;

        public BulletsOutOfBoundsObserver(LevelBounds levelBounds, BulletSystem bulletSystem)
        {
            _levelBounds = levelBounds;
            _bulletSystem = bulletSystem;
        }

        void IInitializable.Initialize() => IGameStateListener.Register(this);

        void IOnFixedUpdateListener.OnFixedUpdate(float delta)
        {
            var bulletsOutOfBounds = _bulletSystem.ActiveBullets.Where(
                b => !_levelBounds.InBounds(b.transform.position)).ToArray();

            foreach (var bullet in bulletsOutOfBounds)
                _bulletSystem.RemoveBullet(bullet);
        }
    }
}