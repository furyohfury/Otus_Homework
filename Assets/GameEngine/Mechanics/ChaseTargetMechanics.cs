using Atomic.Elements;
using Atomic.Objects;
using UnityEngine;

namespace GameEngine
{
    public sealed class ChaseTargetMechanics : IAtomicFixedUpdate
    {
        public AtomicEvent ReachedTargetEvent = new();
        private readonly IAtomicValue<Vector3> _selfPos;
        private readonly IAtomicValue<Vector3> _targetPos;
        private readonly IAtomicValue<float> _stoppingDistance;
        private readonly IAtomicExpression<bool> _enabled;
        private readonly IAtomicVariable<Vector3> _moveDirection;

        public ChaseTargetMechanics(
            IAtomicValue<Vector3> selfPos,
            IAtomicValue<Vector3> targetPos,
            IAtomicValue<float> stoppingDistance,
            IAtomicExpression<bool> enabled,
            IAtomicVariable<Vector3> moveDirection)
        {
            _selfPos = selfPos;
            _targetPos = targetPos;
            _stoppingDistance = stoppingDistance;
            _enabled = enabled;
            _moveDirection = moveDirection;
        }

        void IAtomicFixedUpdate.OnFixedUpdate(float deltaTime)
        {
            if (!_enabled.Value) return;

            var direction = _targetPos.Value - _selfPos.Value;
            if (direction.sqrMagnitude > _stoppingDistance.Value * _stoppingDistance.Value)
            {
                _moveDirection.Value = direction;
            }
            else
            {
                _moveDirection.Value = Vector3.zero;
                ReachedTargetEvent?.Invoke();
            }
        }
    }
}