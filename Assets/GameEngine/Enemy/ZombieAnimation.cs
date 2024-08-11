using System;
using Assets.GameEngine;
using Atomic.Elements;
using UnityEngine;

namespace GameEngine
{
    [Serializable]
    public sealed class ZombieAnimation
    {
        private IAtomicEvent _attackStartEvent;
        private IAtomicEvent _attackEndEvent;
        private IAtomicEvent _attackCDStartEvent;
        [SerializeField]
        private Animator _animator;
        [SerializeField]
        private AnimatorDispatcher _dispatcher;

        private readonly int _isMovingHash = Animator.StringToHash("IsMoving");
        private readonly int _isDeadHash = Animator.StringToHash("IsDead");
        private readonly int _attackEventHash = Animator.StringToHash("AttackEvent");
        private readonly int _takeDamageEventHash = Animator.StringToHash("TakeDamageEvent");

        private IAtomicExpression<bool> _canMove;
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
            _canMove = canMove;
            moveDirection.Subscribe(OnChangeMoveDirection);

            isAlive.Subscribe(OnDead);

            _dispatcher.SubscribeOnEvent("AttackStartEvent", OnAttackStartEventReceived);
            _dispatcher.SubscribeOnEvent("AttackEndEvent", OnAttackEndEventReceived);

            hp.Subscribe(OnHPChanged);

            _canAttack = canAttack;
            attackRequest.Subscribe(OnAttackRequest);
            _attackStartEvent = attackStartEvent;
            _attackEndEvent = attackEndEvent;
            _attackCDStartEvent = attackCDStartEvent;
        }        

        private void OnChangeMoveDirection(Vector3 dir)
        {
            if (_canMove.Value && dir != Vector3.zero)
            {
                _animator.SetBool(_isMovingHash, true);
            }
            else
            {
                _animator.SetBool(_isMovingHash, false);
            }
        }

        private void OnDead(bool alive)
        {
            if (!alive)
            {
                _animator.SetTrigger(_isDeadHash);
            }
        }

        private void OnHPChanged(int hp)
        {
            if (hp > 0)
            {
                _animator.SetTrigger(_takeDamageEventHash);
            }
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