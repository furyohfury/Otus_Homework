using System;
using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    [Serializable]
    public sealed class EnemyAttackAgent : IOnFixedUpdateListener
    {
        public event Action<BulletConfig, Vector2, Vector2> OnFire;

        [SerializeField] private float _countdown = 1f;

        [SerializeField] private WeaponComponent _weaponComponent;
        [SerializeField] private BulletConfig _bulletConfig;

        private Transform _target;
        private float _currentTime;
        private bool _active = false;
        public bool Active { get => _active; set => _active = value; }

        public EnemyAttackAgent(WeaponComponent weaponComponent, BulletConfig bulletConfig)
        {
            _weaponComponent = weaponComponent;
            _bulletConfig = bulletConfig;
        }

        public void Init()
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