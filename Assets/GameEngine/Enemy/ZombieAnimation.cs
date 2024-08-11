using System;
using Assets.GameEngine;
using Atomic.Elements;
using Atomic.Objects;
using UnityEngine;

namespace GameEngine
{
    [Serializable]
    public sealed class ZombieAnimation : IAtomicEnable, IAtomicDisable
    {
        [SerializeField]
        private Animator _animator;
        [SerializeField]
        private AnimatorDispatcher _dispatcher;

        private readonly int _attackEventHash = Animator.StringToHash("AttackEvent");

        private MoveAnimationMechanics _moveAnimationMechanics;
        private DeathAnimationMechanics _deathAnimationMechanics;
        private TakeDamageAnimationMechanics _takeDamageAttackAnimation;

        private IAtomicEvent _attackStartEvent;
        private IAtomicEvent _attackEndEvent;
        private IAtomicEvent _attackCDStartEvent;
        private IAtomicExpression<bool> _canAttack;

        public void Compose(
            IAtomicObservable<Vector3> moveDirection,
            IAtomicExpression<bool> canMove,
            IAtomicObservable<bool> isAlive,
            IAtomicObservable<int> hp,
            IAtomicExpression<bool> canAttack,
            IAtomicEvent attackRequest,
            IAtomicEvent attackStartEvent,
            IAtomicEvent attackEndEvent,
            IAtomicEvent attackCDStartEvent)
        {

            _moveAnimationMechanics = new(moveDirection, canMove, _animator);
            _deathAnimationMechanics = new(isAlive, _animator);
            _takeDamageAttackAnimation = new(hp, _animator);

            _dispatcher.SubscribeOnEvent("AttackStartEvent", OnAttackStartEventReceived);
            _dispatcher.SubscribeOnEvent("AttackEndEvent", OnAttackEndEventReceived);
            _canAttack = canAttack;
            attackRequest.Subscribe(OnAttackRequest);
            _attackStartEvent = attackStartEvent;
            _attackEndEvent = attackEndEvent;
            _attackCDStartEvent = attackCDStartEvent;
        }

        void IAtomicEnable.Enable()
        {
            _moveAnimationMechanics.OnEnable();
            _deathAnimationMechanics.OnEnable();
            _takeDamageAttackAnimation.OnEnable();
        }

        void IAtomicDisable.Disable()
        {
            _moveAnimationMechanics.OnDisable();
            _deathAnimationMechanics.OnDisable();
            _takeDamageAttackAnimation.OnDisable();
        }

        private void OnAttackRequest()
        {
            if (_canAttack.Value)
            {
                _animator.SetTrigger(_attackEventHash);
                _attackCDStartEvent.Invoke();
            }
        }

        private void OnAttackStartEventReceived()
        {
            _attackStartEvent.Invoke();
        }

        private void OnAttackEndEventReceived()
        {
            _attackEndEvent.Invoke();
        }
    }
}