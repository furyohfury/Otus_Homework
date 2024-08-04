using System;
using Atomic.Elements;
using UnityEngine;

namespace GameEngine
{
    [Serializable]
    public class RotationComponent
    {
        public Rigidbody RotationRoot => _rotationRoot;
        public IAtomicExpression<bool> CanRotate;

        [SerializeField] private Rigidbody _rotationRoot;
        [SerializeField] private Vector3 _rotateDirection;
        [SerializeField] private float _rotateRate;        

        public AtomicAction<Vector3> RotateAction;

        public void Compose(IAtomicExpression<bool> canRotate)
        {
            CanRotate = canRotate;
            RotateAction.Compose(Rotate);
        }

        public void Rotate(Vector3 forwardDirection)
        {
            _rotateDirection = forwardDirection;

            if (!CanRotate.Value)
            {
                return;
            }

            if (forwardDirection == Vector3.zero)
            {
                return;
            }

            var targetRotation = Quaternion.LookRotation(_rotateDirection, Vector3.up);
            _rotationRoot.rotation = Quaternion.Lerp(_rotationRoot.rotation, targetRotation, _rotateRate);
        }
    }
}