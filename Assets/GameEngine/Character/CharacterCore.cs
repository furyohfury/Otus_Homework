using System;
using Atomic.Elements;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GameEngine
{
    [Serializable]
    public sealed class CharacterCore
    {
        // Components
        [TitleGroup("Components", alignment: TitleAlignments.Centered, boldTitle: true)]
        public MoveComponent MoveComponent;
        [SerializeField, TitleGroup("Components")]
        private RotationComponent _rotationComponent;
        [TitleGroup("Components")]
        public LifeComponent LifeComponent;
        [TitleGroup("Components")]
        public ShootComponent ShootComponent;
        [TitleGroup("Components")]
        public WeaponMagComponent WeaponMagComponent;
        
        [TitleGroup("Separate variables", alignment: TitleAlignments.Centered, boldTitle: true)]
        public AtomicVariable<Rigidbody> Root;
        [TitleGroup("Separate variables")]
        public AtomicVariable<Vector3> LookDirection;
        [TitleGroup("Separate variables")]
        [TitleGroup("Separate variables"), SerializeField]
        private float _weaponMagRefillCD = 2f;
        [TitleGroup("Separate variables"), ShowInInspector, ReadOnly]
        public AtomicVariable<float> WeaponMagRefillCDTimer = new(0f);

        public MoveMechanics MoveMechanics;
        public LookAtTargetMechanics LookAtTargetMechanics;
        public CooldownMechanics ShootCdMechanics;
        public CooldownMechanics WeaponMagRefillMechanics;

        public void Compose()
        {
            LifeComponent.Compose();

            var canMove = new AtomicAnd();
            canMove.Append(LifeComponent.IsAlive);
            MoveComponent.Compose(canMove);

            var canRotate = new AtomicAnd();
            canRotate.Append(LifeComponent.IsAlive);
            _rotationComponent.Compose(Root, canRotate);

            var canShoot = new AtomicAnd();
            canShoot.Append(LifeComponent.IsAlive);
            canShoot.Append(new AtomicFunction<bool>(() => !WeaponMagComponent.IsEmpty.Value));
            ShootComponent.Compose(canShoot);

            WeaponMagRefillCDTimer.Subscribe(cd =>
            {
                if (cd <= 0 && !WeaponMagComponent.IsFull.Value)
                {
                    WeaponMagComponent.AddBullet.Invoke();
                    WeaponMagRefillCDTimer.Value = _weaponMagRefillCD;
                }
            });
            WeaponMagComponent.Compose(ShootComponent.ShootEvent);

            MoveMechanics = new(MoveComponent.Speed, MoveComponent.MoveDirection, Root, MoveComponent.CanMove);

            var rotRoot = new AtomicFunction<Vector3>(() => Root.Value.position);
            var lookDir = new AtomicFunction<Vector3>(() =>
            {
                var cursorPos = LookDirection.Value;
                return new Vector3(cursorPos.x, Root.Value.position.y, cursorPos.z);
            });
            LookAtTargetMechanics = new(_rotationComponent.RotateAction, lookDir, rotRoot, _rotationComponent.CanRotate);

            ShootCdMechanics = new(ShootComponent.ReloadTimer);
            ShootComponent.ShootEvent.Subscribe(() => WeaponMagRefillCDTimer.Value = _weaponMagRefillCD);
            WeaponMagRefillMechanics = new(WeaponMagRefillCDTimer);
        }
    }
}
