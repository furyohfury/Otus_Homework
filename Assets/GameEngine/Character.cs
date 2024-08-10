using Atomic.Elements;
using Atomic.Objects;
using UnityEngine;

namespace GameEngine
{
    public sealed class Character : AtomicObject
    {
        // Interfaces
        [Get("IsAlive")]
        public IAtomicVariable<bool> IsAlive => _core.LifeComponent.IsAlive;
        [Get(MoveAPI.MOVE_DIRECTION)]
        public IAtomicVariable<Vector3> MoveDirection => _core.MoveComponent.MoveDirection;
        [Get(LifeAPI.TAKE_DAMAGE_ACTION)]
        public IAtomicAction<int> TakeDamageEvent => _core.LifeComponent.TakeDamageEvent;
        [Get("LookDirection")]
        public IAtomicVariable<Vector3> LookDirection => _core.LookDirection;
        [Get("RootPosition")]
        public AtomicFunction<Vector3> RootPosition;
        [Get(ShootAPI.SHOOT_REQUEST)]
        public IAtomicAction ShootRequest => _animation.ShootRequest;

        [SerializeField]
        private CharacterCore _core;

        [SerializeField]
        private CharacterAnimation _animation;

        private void Awake()
        {
            Compose();
        }

        private void Compose()
        {
            _core.Compose();
            _animation.Compose(
                _core.MoveComponent.MoveDirection,
                _core.MoveComponent.CanMove,
                _core.LifeComponent.IsAlive,
                _core.ShootComponent.ShootAction);
            RootPosition = new AtomicFunction<Vector3>(() => _core.RotationComponent.RotationRoot.position);
            AddLogic(_core.MoveMechanics);
            AddLogic(_core.LookAtTargetMechanics);
            AddLogic(_core.ShootCdMechanics);
            AddLogic(_core.WeaponMagRefillMechanics);
        }

        private void Update()
        {
            OnUpdate(Time.deltaTime);
        }

        private void FixedUpdate()
        {
            OnFixedUpdate(Time.fixedDeltaTime);
        }
    }
}
