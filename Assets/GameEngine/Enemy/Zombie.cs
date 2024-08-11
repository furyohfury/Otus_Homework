using Atomic.Elements;
using Atomic.Objects;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GameEngine
{
    public sealed class Zombie : AtomicObject
    {
        [Get(LifeAPI.TAKE_DAMAGE_ACTION)]
        public IAtomicAction<int> TakeDamageEvent => _core.LifeComponent.TakeDamageRequest;
        [Get(LifeAPI.IS_ALIVE)]
        public IAtomicObservable<bool> IsAlive => _core.LifeComponent.IsAlive;

        [SerializeField]
        private ZombieCore _core;
        [SerializeField]
        private ZombieAnimation _animation;
        [SerializeField]
        private ZombieVfx _vfx;
        [SerializeField]
        private ZombieAudio _audio;

        private void Awake()
        {
            _core.Compose();            

            _animation.Compose(
                _core.MoveComponent.MoveDirection,
                _core.MoveComponent.CanMove,
                _core.LifeComponent.IsAlive,
                _core.LifeComponent.HitPoints,
                _core.AttackComponent.CanAttack,
                _core.AttackComponent.AttackRequest,
                _core.AttackComponent.AttackStartEvent,
                _core.AttackComponent.AttackEndEvent,
                _core.AttackComponent.AttackCooldownStartEvent
                );

            _vfx.Compose(_core.LifeComponent.IsAlive);

            _audio.Compose(_core.LifeComponent.IsAlive);

            AddLogic(_core.MoveMechanics);
            AddLogic(_core.TargetDetectionMechanics);
            AddLogic(_core.LookAtTargetMechanics);
            AddLogic(_core.ChaseTargetMechanics);
            AddLogic(_core.CooldownMechanics);
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
