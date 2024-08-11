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
        public AtomicAnd CanShoot = new();
        [ShowInInspector, ReadOnly]
        public AtomicVariable<float> ReloadTimer = new(0);

        [SerializeField]
        private float _reloadTime = 2f;
        [SerializeField]
        private AtomicEntity _bulletPrefab;
        [SerializeField]
        private Transform _firePoint;

        [ShowInInspector, ReadOnly]
        private AtomicFunction<bool> _loaded;

        public void Compose(IAtomicExpression<bool> canFire = null)
        {
            ShootAction?.Subscribe(Shoot);
            if (canFire != null)
            {
                CanShoot.Append(canFire);
            }
            _loaded = new AtomicFunction<bool>(() => ReloadTimer.Value <= 0);
            CanShoot.Append(_loaded);
        }

        public void Shoot()
        {
            if (!CanShoot.Invoke()) return;

            var bullet = GameObject.Instantiate(_bulletPrefab, _firePoint.position, _firePoint.rotation);
            if (bullet.TryGetVariable<Vector3>(MoveAPI.MOVE_DIRECTION, out var moveDirection))
            {
                moveDirection.Value = _firePoint.forward;
            }
            ReloadTimer.Value = _reloadTime;
            ShootEvent.Invoke();
        }
    }
}
