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
            RotationRoot.rotation = Quaternion.Lerp(RotationRoot.rotation, targetRotation, RotateRate.Value);
        }
    }
}