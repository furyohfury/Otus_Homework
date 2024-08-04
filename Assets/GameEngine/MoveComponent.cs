using System;
using Atomic.Elements;
using UnityEngine;

namespace GameEngine
{
    [Serializable]
    public class MoveComponent
    {
        public AtomicVariable<Vector3> MoveDirection;
        public IAtomicExpression<bool> CanMove;
        public MoveMechanics MoveMechanics;

        [SerializeField]
        private AtomicVariable<float> _speed = new(5f);
        [SerializeField]
        private Rigidbody _rigidBody;

        public void Compose(IAtomicExpression<bool> canMove)
        {
            CanMove = canMove;
            MoveMechanics = new(_speed, MoveDirection, _rigidBody, CanMove);
        }
    }
}