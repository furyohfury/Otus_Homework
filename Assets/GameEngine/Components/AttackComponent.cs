using System;
using Atomic.Elements;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GameEngine
{
    [Serializable]
    public sealed class AttackComponent
    {
        public AtomicEvent AttackRequest;
        public AtomicEvent AttackStartEvent;
        public AtomicEvent AttackEndEvent;
        public AtomicEvent AttackCooldownStartEvent;
        public AtomicAnd CanAttack = new();
        [ShowInInspector, ReadOnly]
        public AtomicVariable<float> ReloadTimer = new(0);
        [SerializeField]
        private AtomicVariable<int> _damage = new(1);
        [SerializeField]
        private float _attackCooldown = 2f;
        [SerializeField]
        private MeleeAttackHitBox _hitboxCollider;

        private AtomicFunction<bool> _readyToAttack;

        public void Compose()
        {
            AttackStartEvent.Subscribe(OnAttackStart);
            AttackEndEvent.Subscribe(OnAttackEnd);
            _readyToAttack = new(() => ReloadTimer.Value <= 0);
            CanAttack.Append(_readyToAttack);
            _hitboxCollider.Compose(_damage);
            AttackCooldownStartEvent.Subscribe(OnAttackCooldownStart);
        }

        private void OnAttackCooldownStart()
        {
            ReloadTimer.Value = _attackCooldown;
        }

        private void OnAttackStart()
        {
            _hitboxCollider.Enable();
        }

        private void OnAttackEnd()
        {
            _hitboxCollider.Disable();
        }
    }
}