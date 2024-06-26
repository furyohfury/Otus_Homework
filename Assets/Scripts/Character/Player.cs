using System;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class Player : MonoBehaviour
    {
        public event Action OnPlayerDied;

        [SerializeField] private HitPointsComponent _hpComponent;
        [SerializeField] private WeaponComponent _weaponComponent;
        [SerializeField] private MoveComponent _moveComponent;

        public Vector3 GetWeaponPosition => _weaponComponent.Position;
        public Quaternion GetWeaponRotation => _weaponComponent.Rotation;

        private void Awake()
        {
            _hpComponent.OnHPEnded += PlayerDied;
        }

        private void OnDestroy()
        {
            _hpComponent.OnHPEnded -= PlayerDied;
        }

        private void OnValidate()
        {
            gameObject.layer = (int)PhysicsLayer.CHARACTER;
        }        

        public void Move(Vector3 pos) => _moveComponent.MoveByRigidbodyVelocity(pos);

        private void PlayerDied()
        {
            OnPlayerDied?.Invoke();
        }
    }
}