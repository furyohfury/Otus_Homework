using System;
using Atomic.Elements;
using UnityEngine;

namespace GameEngine
{
    [Serializable]
    public class RotationComponent
    {
        public AtomicEvent<Vector3> RotateAction;
        public IAtomicExpression<bool> CanRotate;
        public Rigidbody RotationRoot;
        public AtomicVariable<float> RotateRate;

        public void Compose(IAtomicExpression<bool> canRotate)
        {
            CanRotate = canRotate;
        }
    }
}