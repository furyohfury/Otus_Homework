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
        public MoveComponent MoveComponent;
        public RotationComponent RotationComponent;
        public LifeComponent LifeComponent;
        public ShootComponent ShootComponent;
        public WeaponMagComponent WeaponMagComponent;

        [Space]
        public AtomicVariable<Vector3> LookDirection;
        [SerializeField]
        private float _weaponMagRefillCD = 2f;
        [ShowInInspector, ReadOnly]
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
            RotationComponent.Compose(canRotate);

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

            MoveMechanics = new(MoveComponent.Speed, MoveComponent.MoveDirection, MoveComponent.Root, MoveComponent.CanMove);

            var rotRoot = new AtomicFunction<Vector3>(() => RotationComponent.RotationRoot.position);
            var lookDir = new AtomicFunction<Vector3>(() =>
            {
                var cursorPos = LookDirection.Value;
                return new Vector3(cursorPos.x, RotationComponent.RotationRoot.position.y, cursorPos.z);
            });
            LookAtTargetMechanics = new(RotationComponent.RotateAction, lookDir, rotRoot, RotationComponent.CanRotate);

            ShootCdMechanics = new(ShootComponent.ReloadTimer);
            ShootComponent.ShootEvent.Subscribe(() => WeaponMagRefillCDTimer.Value = _weaponMagRefillCD);
            WeaponMagRefillMechanics = new(WeaponMagRefillCDTimer);
        }
    }
}
