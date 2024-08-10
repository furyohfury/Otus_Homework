using System;
using Atomic.Elements;
using Atomic.Extensions;
using Atomic.Objects;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GameEngine
{
    [Serializable]
    public class ShootComponent
    {
        public AtomicEvent ShootRequest;
        public AtomicEvent ShootAction;
        public AtomicEvent ShootEvent;
        public IAtomicExpression<bool> CanFireCondition;

        [SerializeField] private float _reloadTime = 2f;        
        [SerializeField] private AtomicEntity _bulletPrefab;
        [SerializeField] private Transform _firePoint;

        [ShowInInspector, ReadOnly]
        public AtomicVariable<float> ReloadTimer = new(0);
        [ShowInInspector, ReadOnly]
        private readonly AtomicFunction<bool> _canFire = new();
        private AtomicFunction<bool> _isReloading;

        public void Compose(IAtomicExpression<bool> canFire = null)
        {
            ShootAction?.Subscribe(Shoot);
            if (canFire == null)
            {
                CanFireCondition = new AtomicAnd();
            }
            else
            {
                CanFireCondition = canFire;
            }
            _isReloading = new(() => ReloadTimer.Value > 0);
            _canFire.Compose(() => !_isReloading.Value && CanFireCondition.Value);
        }

        public void Shoot()
        {
            if (!_canFire.Value) return;

            var bullet = GameObject.Instantiate(_bulletPrefab, _firePoint.position, _firePoint.rotation);

            if (bullet.TryGetVariable<Vector3>(MoveAPI.MOVE_DIRECTION, out var moveDirection))
            {
                moveDirection.Value = _firePoint.forward;
            }

            ReloadTimer.Value = _reloadTime;

            ShootEvent.Invoke();
            Debug.Log("Fire!");
        }
    }
}
