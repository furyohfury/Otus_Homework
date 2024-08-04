using Atomic.Elements;
using UnityEngine;

namespace GameEngine
{
    public sealed class RotateMechanics
    {
        private readonly IAtomicEvent<Vector3> _rotateAction;
        private readonly IAtomicValue<float> _rate;
        private readonly Rigidbody _rotationRoot;
        private readonly IAtomicExpression<bool> _canRotate;

        public RotateMechanics(IAtomicEvent<Vector3> rotateAction, IAtomicValue<float> rate, Rigidbody rigidbody, IAtomicExpression<bool> canRotate)
        {            
            _rate = rate;
            _rotationRoot = rigidbody;
            _canRotate = canRotate;
            _rotateAction = rotateAction;
            _rotateAction.Subscribe(Rotate);
        }

        public void Rotate(Vector3 forwardDirection)
        {

            if (!_canRotate.Value)
            {
                return;
            }

            if (forwardDirection == Vector3.zero)
            {
                return;
            }

            var targetRotation = Quaternion.LookRotation(forwardDirection, Vector3.up);
            _rotationRoot.rotation = Quaternion.Lerp(_rotationRoot.rotation, targetRotation, _rate.Value);
        }
    }
}