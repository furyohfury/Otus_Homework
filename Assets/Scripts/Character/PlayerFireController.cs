using UnityEngine;

namespace ShootEmUp
{
    public class PlayerFireController : MonoBehaviour
    {
        [SerializeField] private BulletSystem _bulletSystem;
        [SerializeField] private InputListener _inputListener;
        [SerializeField] private WeaponComponent _playerWeaponComponent;

        [SerializeField] private BulletConfig _bulletConfig;

        private void OnEnable()
        {
            _inputListener.OnFireButton += PlayerFireBullet;
        }
        private void OnDisable()
        {
            _inputListener.OnFireButton -= PlayerFireBullet;
        }

        private void PlayerFireBullet()
        {
            _bulletSystem.FireBullet(_bulletConfig,
                _playerWeaponComponent.Position,
                _playerWeaponComponent.Rotation * transform.up * _bulletConfig.speed);
        }
    }
}