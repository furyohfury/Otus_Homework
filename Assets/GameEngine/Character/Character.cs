using Atomic.Elements;
using Atomic.Objects;
using UnityEngine;

namespace GameEngine
{
    public sealed class Character : AtomicObject
    {
        // Interfaces
        [Get(LifeAPI.IS_ALIVE)]
        public IAtomicObservable<bool> IsAlive => _core.LifeComponent.IsAlive;
        [Get(LifeAPI.HIT_POINTS)]
        public IAtomicObservable<int> HitPoints => _core.LifeComponent.HitPoints;
        [Get(MoveAPI.MOVE_DIRECTION)]
        public IAtomicVariable<Vector3> MoveDirection => _core.MoveComponent.MoveDirection;
        [Get(LifeAPI.TAKE_DAMAGE_ACTION)]
        public IAtomicAction<int> TakeDamageEvent => _core.LifeComponent.TakeDamageRequest;
        [Get(RotateAPI.LOOK_DIRECTION)]
        public IAtomicVariable<Vector3> LookDirection => _core.LookDirection;
        [Get("RootPosition")]
        public AtomicFunction<Vector3> RootPosition;
        [Get(ShootAPI.SHOOT_REQUEST)]
        public IAtomicAction ShootRequest => _core.ShootComponent.ShootRequest;
        [Get(WeaponMagAPI.CURRENT_BULLET_COUNT)]
        public IAtomicObservable<int> CurrentBulletCount => _core.WeaponMagComponent.CurrentCount;
        [Get(WeaponMagAPI.MAX_BULLET_COUNT)]
        public IAtomicValue<int> MaxBulletCount => _core.WeaponMagComponent.MaxCount;

        // Sections
        [SerializeField]
        private CharacterCore _core;

        [SerializeField]
        private CharacterAnimation _animation;

        [SerializeField]
        private CharacterVfx _vfx;

        [SerializeField]
        private CharacterAudio _audio;

        private void Awake()
        {
            Compose();
        }

        private void Compose()
        {
            _core.Compose();

            _animation.Compose(_core.MoveComponent.MoveDirection,
                               _core.MoveComponent.CanMove,
                               _core.LifeComponent.IsAlive,
                               _core.ShootComponent.CanShoot,
                               _core.ShootComponent.ShootRequest,
                               _core.ShootComponent.ShootAction,
                               _core.LifeComponent.HitPoints);

            _vfx.Compose(_core.ShootComponent.ShootEvent,
                         _core.LifeComponent.TakeDamageRequest);

            _audio.Compose(_core.ShootComponent.ShootEvent, _core.LifeComponent.TakeDamageEvent, _core.LifeComponent.IsAlive);

            RootPosition = new AtomicFunction<Vector3>(() => _core.Root.Value.position);

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
