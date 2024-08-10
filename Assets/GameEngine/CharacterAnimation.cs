using System;
using Assets.GameEngine;
using Atomic.Elements;
using UnityEngine;

namespace GameEngine
{
    [Serializable]
    public sealed class CharacterAnimation
    {
        private readonly int _isMovingHash = Animator.StringToHash("IsMoving");
        private readonly int _isDeadHash = Animator.StringToHash("IsDead");
        private readonly int _shootEventHash = Animator.StringToHash("ShootEvent");
        [SerializeField]
        private Animator _animator;
        [SerializeField]
        private AnimatorDispatcher _dispatcher;
        public IAtomicEvent ShootAction;
        public AtomicEvent ShootRequest = new();

        public void Compose(
            IAtomicObservable<Vector3> moveDirection, 
            IAtomicExpression<bool> canMove, 
            IAtomicObservable<bool> isAlive,
            IAtomicEvent shootAction)
        {
            moveDirection.Subscribe(dir =>
            {
                if (canMove.Value && dir != Vector3.zero)
                {
                    _animator.SetBool(_isMovingHash, true);
                }
                else
                {
                    _animator.SetBool(_isMovingHash, false);
                }
            });

            isAlive.Subscribe(alive =>
            {
                if (!alive)
                {
                    _animator.SetTrigger(_isDeadHash);
                    var bodyLayer = _animator.GetLayerIndex("Body");
                    var legsLayer = _animator.GetLayerIndex("Legs");
                    _animator.SetLayerWeight(bodyLayer, 0);
                    _animator.SetLayerWeight(legsLayer, 0);
                }
            });
            ShootAction = shootAction;
            ShootRequest.Subscribe(() => _animator.SetTrigger(_shootEventHash));

            _dispatcher.SubscribeOnEvent("ShootAction", OnEventReceived);
        }

        private void OnEventReceived()
        {
            ShootAction?.Invoke();
        }
    }
}