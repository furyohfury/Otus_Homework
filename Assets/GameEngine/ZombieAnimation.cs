using System;
using Assets.GameEngine;
using Atomic.Elements;
using UnityEngine;

namespace GameEngine
{
    [Serializable]
    public sealed class ZombieAnimation
    {
        public AtomicEvent AttackStartEvent = new();
        public AtomicEvent AttackEndEvent = new();
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
            IAtomicEvent attackStartEvent)
        {
            _canMove = canMove;
            moveDirection.Subscribe(OnChangeMoveDirection);

            isAlive.Subscribe(OnDead);

            _dispatcher.SubscribeOnEvent("AttackStartEvent", OnAttackStartEventReceived);
            _dispatcher.SubscribeOnEvent("AttackEndEvent", OnAttackEndEventReceived);

            hp.Subscribe(OnHPChanged);

            _canAttack = canAttack;
            attackStartEvent.Subscribe(OnAttackStart);
        }

        private void OnAttackStart()
        {
            if (_canAttack.Value)
            {
                _animator.SetTrigger(_attackEventHash);
                AttackStartEvent.Invoke();
            }
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

        private void OnAttackStartEventReceived()
        {
            AttackStartEvent.Invoke();
        }

        private void OnAttackEndEventReceived()
        {
            AttackEndEvent.Invoke();
        }
    }
}