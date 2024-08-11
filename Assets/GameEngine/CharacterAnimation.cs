using System;
using Assets.GameEngine;
using Atomic.Elements;
using UnityEngine;

namespace GameEngine
{
    [Serializable]
    public sealed class CharacterAnimation
    {
        public AtomicEvent ShootRequest = new();
        [SerializeField]
        private Animator _animator;
        [SerializeField]
        private AnimatorDispatcher _dispatcher;

        private readonly int _isMovingHash = Animator.StringToHash("IsMoving");
        private readonly int _isDeadHash = Animator.StringToHash("IsDead");
        private readonly int _shootEventHash = Animator.StringToHash("ShootEvent");
        private readonly int _takeDamageEventHash = Animator.StringToHash("TakeDamageEvent");

        private IAtomicEvent _shootAction;
        private IAtomicExpression<bool> _canShoot;
        private IAtomicExpression<bool> _canMove;

        public void Compose(
            IAtomicObservable<Vector3> moveDirection,
            IAtomicExpression<bool> canMove,
            IAtomicObservable<bool> isAlive,
            IAtomicExpression<bool> canShoot,
            IAtomicEvent shootRequest,
            IAtomicEvent shootAction,
            IAtomicObservable<int> hp)
        {
            _canMove = canMove;
            moveDirection.Subscribe(OnChangeMoveDirection);

            isAlive.Subscribe(OnDead);

            _canShoot = canShoot;
            _shootAction = shootAction;
            shootRequest.Subscribe(OnShootRequest);

            _dispatcher.SubscribeOnEvent("ShootAction", OnEventReceived);

            hp.Subscribe(OnHPChanged);
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
                var bodyLayer = _animator.GetLayerIndex("Body");
                var legsLayer = _animator.GetLayerIndex("Legs");
                _animator.SetLayerWeight(bodyLayer, 0);
                _animator.SetLayerWeight(legsLayer, 0);
            }
        }

        private void OnHPChanged(int hp)
        {
            if (hp > 0)
            {
                _animator.SetTrigger(_takeDamageEventHash);
            }
        }

        private void OnShootRequest()
        {
            if (_canShoot.Value)
            {
                _animator.SetTrigger(_shootEventHash);
            }
        }

        private void OnEventReceived()
        {
            _shootAction?.Invoke();
        }
    }
}