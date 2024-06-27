using System;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyAttackAgent : MonoBehaviour, IOnFixedUpdateListener
    {
        public event Action<BulletConfig, Vector2, Vector2> OnFire;

        public bool Active { get => _active; set { _active = value; } }

        private bool _active = false;
        [SerializeField] private float _countdown;
        [SerializeField] private WeaponComponent _weaponComponent;
        [SerializeField] private BulletConfig _bulletConfig;
        private Transform _target;
        private float _currentTime;

        private void Awake()
        {
            IGameStateListener.Register(this);
        }

        public void OnFixedUpdate(float delta)
        {
            FireCycle();
        }

        public void SetTarget(Transform target)
        {
            _target = target;
            ResetCountdown();
        }

        public void ResetCountdown()
        {
            _currentTime = _countdown;
        }

        private void FireCycle()
        {
            _currentTime -= Time.fixedDeltaTime;
            if (_currentTime <= 0)
            {
                Fire();
                _currentTime += _countdown;
            }
        }

        private void Fire()
        {
            if (!Active)
                return;

            var startPosition = _weaponComponent.Position;
            var direction = (Vector2)_target.position - startPosition;
            direction.Normalize();
            OnFire?.Invoke(_bulletConfig, startPosition, direction * _bulletConfig.speed);
        }
    }
}