using System;
using Atomic.Elements;
using UnityEngine;

namespace GameEngine
{
    [Serializable]
    public class MoveComponent
    {
        public AtomicVariable<Vector3> MoveDirection;
        public AtomicVariable<float> Speed = new(5f);
        public AtomicVariable<Rigidbody> _rigidBody;
        public IAtomicExpression<bool> CanMove;

        public void Compose(IAtomicExpression<bool> canMove)
        {
            CanMove = canMove;
        }
    }
}