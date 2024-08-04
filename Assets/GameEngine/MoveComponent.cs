using System;
using Atomic.Elements;
using UnityEngine;

namespace GameEngine
{
    [Serializable]
    public class MoveComponent
    {
        public AtomicVariable<Vector3> MoveDirection;        
        public AtomicAnd CanMove = new();
        public MoveMechanics MoveMechanics;

        [SerializeField]
        private AtomicVariable<float> _speed = new(5f);
        [SerializeField]
        private Rigidbody _rigidBody;

        public void Compose()
        {
            MoveMechanics = new(_speed, MoveDirection, _rigidBody, CanMove);
        }
    }
}