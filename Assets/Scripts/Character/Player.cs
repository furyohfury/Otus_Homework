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

        private void OnEnable()
        {
            _hpComponent.OnHPEnded += PlayerDied;
        }        

        private void OnDisable()
        {
            _hpComponent.OnHPEnded += PlayerDied;
        }

        private void OnValidate()
        {
            gameObject.layer = (int)PhysicsLayer.CHARACTER;
        }
        private void PlayerDied()
        {
            OnPlayerDied?.Invoke();
        }
    }
}