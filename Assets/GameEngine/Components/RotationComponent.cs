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
        public AtomicVariable<float> RotateRate;

        private IAtomicValue<Rigidbody> _root;

        public void Compose(IAtomicValue<Rigidbody> root, IAtomicExpression<bool> canRotate)
        {
            _root = root;
            CanRotate = canRotate;
            RotateAction.Subscribe(Rotate);
        }

        public void Rotate(Vector3 forwardDirection)
        {

            if (!CanRotate.Value)
            {
                return;
            }

            if (forwardDirection == Vector3.zero)
            {
                return;
            }

            var targetRotation = Quaternion.LookRotation(forwardDirection, Vector3.up);
            _root.Value.rotation = Quaternion.Lerp(_root.Value.rotation, targetRotation, RotateRate.Value);
        }
    }
}