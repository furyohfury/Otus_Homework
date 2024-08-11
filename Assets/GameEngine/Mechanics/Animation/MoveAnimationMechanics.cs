using Atomic.Elements;
using UnityEngine;

namespace GameEngine
{
    public sealed class MoveAnimationMechanics
    {
        private readonly Animator _animator;
        private readonly IAtomicExpression<bool> _canMove;
        private readonly IAtomicObservable<Vector3> _moveDirection;
        private readonly int _isMovingHash = Animator.StringToHash("IsMoving");

        public MoveAnimationMechanics(IAtomicObservable<Vector3> moveDirection,
                                      IAtomicExpression<bool> canMove,
                                      Animator animator)
        {
            _moveDirection = moveDirection;
            _canMove = canMove;
            _animator = animator;
        }

        public void OnEnable()
        {
            _moveDirection.Subscribe(OnChangeMoveDirection);
        }

        public void OnDisable()
        {
            _moveDirection.Unsubscribe(OnChangeMoveDirection);
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
    }
}