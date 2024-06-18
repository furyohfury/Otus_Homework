using System.Linq;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class BulletsOutOfBoundsObserver : MonoBehaviour
    {
        [SerializeField] private LevelBounds _levelBounds;
        [SerializeField] private BulletSystem _bulletSystem;

        private void FixedUpdate()
        {
            var bulletsOutOfBounds = _bulletSystem.ActiveBullets.Where(
                b => !_levelBounds.InBounds(b.transform.position)).ToArray();

            foreach (var bullet in bulletsOutOfBounds)
                _bulletSystem.RemoveBullet(bullet);
        }
    }
}