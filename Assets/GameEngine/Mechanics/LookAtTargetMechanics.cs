using Atomic.Elements;
using Atomic.Objects;
using UnityEngine;

namespace GameEngine
{
    public class LookAtTargetMechanics : IAtomicUpdate
    {
        private readonly IAtomicAction<Vector3> _rotateAction;
        private readonly IAtomicValue<Vector3> _targetPoint;
        private readonly IAtomicValue<Vector3> _selfPosition;
        private readonly IAtomicExpression<bool> _isEnabled;

        public LookAtTargetMechanics(
            IAtomicAction<Vector3> rotateAction,
            IAtomicValue<Vector3> targetPoint,
            IAtomicValue<Vector3> transform,
            IAtomicExpression<bool> isEnabled)
        {
            _rotateAction = rotateAction;
            _targetPoint = targetPoint;
            _selfPosition = transform;
            _isEnabled = isEnabled;
        }

        void IAtomicUpdate.OnUpdate(float deltaTime)
        {
            if (!_isEnabled.Value)
            {
                return;
            }

            var direction = _targetPoint.Value - _selfPosition.Value;
            _rotateAction.Invoke(direction);
        }
    }
}
