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
        public IAtomicExpression<bool> CanMove;

        private IAtomicValue<Rigidbody> _root;

        public void Compose(IAtomicValue<Rigidbody> root, IAtomicExpression<bool> canMove = null)
        {
            _root = root;
            if (canMove == null)
            {
                CanMove = new AtomicAnd();
            }
            else
            {
                CanMove = canMove;
            }
        }
    }
}