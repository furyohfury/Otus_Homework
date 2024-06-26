using System.Linq;
using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public sealed class BulletsOutOfBoundsObserver : IInitializable, IOnFixedUpdateListener
    {
        [SerializeField] private LevelBounds _levelBounds;
        [SerializeField] private BulletSystem _bulletSystem;

        public void Initialize()
        {
            IGameStateListener.Register(this);
        }
        public void OnFixedUpdate(float delta)
        {
            var bulletsOutOfBounds = _bulletSystem.ActiveBullets.Where(
                b => !_levelBounds.InBounds(b.transform.position)).ToArray();

            foreach (var bullet in bulletsOutOfBounds)
                _bulletSystem.RemoveBullet(bullet);
        }
    }
}