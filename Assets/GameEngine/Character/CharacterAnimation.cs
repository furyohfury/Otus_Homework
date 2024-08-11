using System;
using Assets.GameEngine;
using Atomic.Elements;
using Atomic.Objects;
using UnityEngine;

namespace GameEngine
{
    [Serializable]
    public sealed class CharacterAnimation : IAtomicEnable, IAtomicDisable
    {
        public AtomicEvent ShootRequest = new();
        [SerializeField]
        private Animator _animator;
        [SerializeField]
        private AnimatorDispatcher _dispatcher;

        private readonly int _shootEventHash = Animator.StringToHash("ShootEvent");

        private MoveAnimationMechanics _moveAnimationMechanics;
        private DeathAnimationMechanics _deathAnimationMechanics;
        private TakeDamageAnimationMechanics _takeDamageAttackAnimation;
        private IAtomicEvent _shootAction;
        private IAtomicEvent _shootRequest;
        private IAtomicExpression<bool> _canShoot;

        public void Compose(IAtomicObservable<Vector3> moveDirection,
                            IAtomicExpression<bool> canMove,
                            IAtomicObservable<bool> isAlive,
                            IAtomicExpression<bool> canShoot,
                            IAtomicEvent shootRequest,
                            IAtomicEvent shootAction,
                            IAtomicObservable<int> hp)
        {
            _moveAnimationMechanics = new(moveDirection, canMove, _animator);
            _deathAnimationMechanics = new(isAlive, _animator);
            _takeDamageAttackAnimation = new(hp, _animator);

            _canShoot = canShoot;
            _shootAction = shootAction;            
            _shootRequest = shootRequest;
            _dispatcher.SubscribeOnEvent("ShootAction", OnEventReceived);
        }

        void IAtomicEnable.Enable()
        {
            _moveAnimationMechanics.OnEnable();
            _deathAnimationMechanics.OnEnable();
            _takeDamageAttackAnimation.OnEnable();

            _shootRequest.Subscribe(OnShootRequest);
        }
        void IAtomicDisable.Disable()
        {
            _moveAnimationMechanics.OnDisable();
            _deathAnimationMechanics.OnDisable();
            _takeDamageAttackAnimation.OnDisable();

            _shootRequest.Unsubscribe(OnShootRequest);
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