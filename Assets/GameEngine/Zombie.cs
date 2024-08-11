using Atomic.Elements;
using Atomic.Objects;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GameEngine
{
    public sealed class Zombie : AtomicObject
    {
        [Get(LifeAPI.TAKE_DAMAGE_ACTION)]
        public IAtomicAction<int> TakeDamageEvent => _core.LifeComponent.TakeDamageEvent;

        [SerializeField]
        private ZombieCore _core;
        [SerializeField]
        private ZombieAnimation _animation;

        private void Awake()
        {
            _core.Compose(_animation.AttackStartEvent, _animation.AttackEndEvent);
            AddLogic(_core.MoveMechanics);
            AddLogic(_core.TargetDetectionMechanics);
            AddLogic(_core.LookAtTargetMechanics);
            AddLogic(_core.ChaseTargetMechanics);
            AddLogic(_core.CooldownMechanics);

            _animation.Compose(
                _core.MoveComponent.MoveDirection,
                _core.MoveComponent.CanMove,
                _core.LifeComponent.IsAlive,
                _core.LifeComponent.HitPoints,
                _core.AttackComponent.CanAttack,
                _core.ChaseTargetMechanics.ReachedTargetEvent                
                );
        }

        private void Update()
        {
            OnUpdate(Time.deltaTime);
        }

        private void FixedUpdate()
        {
            OnFixedUpdate(Time.fixedDeltaTime);
        }

#if UNITY_EDITOR
        private bool _showRadius = false;
        [Button]
        public void ShowRadiuses()
        {
            _showRadius = !_showRadius;
        }

        private void OnDrawGizmos()
        {
            if (!_showRadius) return;
            Gizmos.color = Color.yellow;
            Gizmos.DrawSphere(transform.position, _core.DetectionRadius.Value);
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(transform.position, _core.StoppingDistance.Value);
        }
#endif
    }
}
