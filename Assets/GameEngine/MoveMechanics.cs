using Atomic.Elements;
using Atomic.Objects;
using UnityEngine;

namespace GameEngine
{
    public sealed class MoveMechanics : IAtomicFixedUpdate
    {
        private readonly IAtomicValue<float> _speed;
        private readonly IAtomicValue<Vector3> _moveDirection;
        private readonly IAtomicExpression<bool> _canMove;
        private readonly IAtomicValue<Rigidbody> _rigidbody;

        public MoveMechanics(IAtomicValue<float> speed, 
            IAtomicValue<Vector3> moveDirection, 
            IAtomicValue<Rigidbody> rigidbody, 
            IAtomicExpression<bool> canMove)
        {
            _speed = speed;
            _moveDirection = moveDirection;
            _rigidbody = rigidbody;
            _canMove = canMove;
        }

        void IAtomicFixedUpdate.OnFixedUpdate(float deltaTime)
        {
            if (_canMove.Value)
            {
                _rigidbody.Value.MovePosition(_rigidbody.Value.position + _speed.Value * deltaTime * _moveDirection.Value.normalized);
            }
        }
    }
}