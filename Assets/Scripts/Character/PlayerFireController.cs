using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public class PlayerFireController : IInitializable
    {
        private readonly BulletSystem _bulletSystem;
        private readonly InputListener _inputListener;
        private readonly Player _player;

        private readonly BulletConfig _bulletConfig;

        [Inject]
        public PlayerFireController(BulletSystem bulletSystem, InputListener inputListener, BulletConfig bulletConfig, Player player)
        {
            _bulletSystem = bulletSystem;
            _inputListener = inputListener;
            _bulletConfig = bulletConfig;
            _player = player;
        }

        void IInitializable.Initialize() => _inputListener.OnFireButton += PlayerFireBullet;

        private void PlayerFireBullet()
        {
            _bulletSystem.FireBullet(_bulletConfig,
                _player.GetWeaponPosition,
                _player.GetWeaponRotation * Vector3.up * _bulletConfig.speed);
        }
    }
}