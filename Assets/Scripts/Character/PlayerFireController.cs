using UnityEngine;

namespace ShootEmUp
{
    public class PlayerFireController : MonoBehaviour
    {
        [SerializeField] private BulletSystem _bulletSystem;
        [SerializeField] private InputListener _inputListener;
        [SerializeField] private WeaponComponent _playerWeaponComponent; // todo see if can delete for enemy

        [SerializeField] private BulletConfig _bulletConfig;

        private void OnEnable()
        {
            _inputListener.OnPlayerFire += PlayerFireBullet;
        }
        private void OnDisable()
        {
            _inputListener.OnPlayerFire -= PlayerFireBullet;
        }

        private void PlayerFireBullet()
        {
            _bulletSystem.FireBullet(_bulletConfig,
                _playerWeaponComponent.Position,
                _playerWeaponComponent.Rotation * transform.up * _bulletConfig.speed);
        }
    }
}