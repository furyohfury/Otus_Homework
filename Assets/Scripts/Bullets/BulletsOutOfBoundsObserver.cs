using System.Linq;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class BulletsOutOfBoundsObserver : MonoBehaviour
    {
        [SerializeField] private LevelBounds _levelBounds;
        [SerializeField] private BulletFactory _bulletFactory;

        private void FixedUpdate()
        {
            var bulletsOutOfBounds = _bulletFactory.ActiveBullets.Where(
                b => !_levelBounds.InBounds(b.transform.position)).ToArray();

            foreach (var bullet in bulletsOutOfBounds)
                _bulletFactory.RemoveBullet(bullet);
        }
    }
}