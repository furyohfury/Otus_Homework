using UnityEngine;

namespace ShootEmUp
{
    public sealed class BulletSystem : MonoBehaviour
    {
        [SerializeField] private BulletFactory _bulletFactory;

        public Bullet FireBullet(BulletConfig config, Vector2 position, Vector2 velocity)
        {
            Bullet bullet = _bulletFactory.GetBullet(config);
            bullet.SetPosition(position);
            bullet.SetVelocity(velocity);
            bullet.OnCollisionEntered += OnBulletCollision;
            return bullet;
        }

        private void OnBulletCollision(Bullet bullet, Collision2D collision)
        {
            bullet.OnCollisionEntered -= OnBulletCollision;
            _bulletFactory.RemoveBullet(bullet);
        }
    }
}