using System.Linq;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class BulletsOutOfBoundsObserver : MonoBehaviour, IOnFixedUpdateListener
    {
        [SerializeField] private LevelBounds _levelBounds;
        [SerializeField] private BulletSystem _bulletSystem;

        private void Awake()
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