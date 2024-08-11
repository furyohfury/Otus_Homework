using System;
using Atomic.Elements;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GameEngine
{
    [Serializable]
    public sealed class AttackComponent
    {
        public AtomicAnd CanAttack = new();
        private IAtomicEvent _attackStartEvent;
        private IAtomicEvent _attackEndEvent;
        public AtomicVariable<int> Damage = new(1);
        [SerializeField]
        private MeleeAttackHitBox _hitboxCollider;
        public float AttackCooldown = 2f;
        [ShowInInspector, ReadOnly]
        public AtomicVariable<float> ReloadTimer = new(0);
        private AtomicFunction<bool> _readyToAttack;

        public void Compose(IAtomicEvent attackStartEvent, IAtomicEvent attackEndEvent)
        {
            _attackStartEvent = attackStartEvent;
            _attackEndEvent = attackEndEvent;
            _attackStartEvent.Subscribe(OnAttackStart);
            _attackEndEvent.Subscribe(OnAttackEnd);
            _readyToAttack = new(() => ReloadTimer.Value <= 0);
            CanAttack.Append(_readyToAttack);
            _hitboxCollider.Compose(Damage);
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