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
        private readonly Rigidbody _rb;

        public MoveMechanics(IAtomicValue<float> speed, IAtomicValue<Vector3> moveDirection, Rigidbody rb, IAtomicExpression<bool> canMove)
        {
            _speed = speed;
            _moveDirection = moveDirection;
            _rb = rb;
            _canMove = canMove;
        }

        void IAtomicFixedUpdate.OnFixedUpdate(float deltaTime)
        {
            if (_canMove.Value)
            {
                _rb.MovePosition(_rb.position + _speed.Value * deltaTime * _moveDirection.Value.normalized);
            }
        }
    }
}