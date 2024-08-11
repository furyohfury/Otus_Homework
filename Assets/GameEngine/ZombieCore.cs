﻿using System;
using Atomic.Elements;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GameEngine
{
    [Serializable]
    public class ZombieCore
    {
        [SerializeField]
        public LifeComponent LifeComponent;
        [SerializeField]
        public MoveComponent MoveComponent;
        [SerializeField]
        public RotationComponent RotationComponent;
        public AttackComponent AttackComponent;

        [ShowInInspector, ReadOnly, Space]
        private readonly AtomicVariable<GameObject> _target = new();
        public AtomicVariable<float> DetectionRadius;
        public AtomicVariable<LayerMask> _playerLayer;
        public AtomicVariable<float> StoppingDistance;

        public MoveMechanics MoveMechanics;
        public TargetDetectionMechanics TargetDetectionMechanics;
        public LookAtTargetMechanics LookAtTargetMechanics;
        public ChaseTargetMechanics ChaseTargetMechanics;
        public CooldownMechanics CooldownMechanics;

        public void Compose(IAtomicEvent attackStartEvent, IAtomicEvent attackEndEvent)
        {
            LifeComponent.Compose();

            var canMove = new AtomicAnd();
            canMove.Append(LifeComponent.IsAlive);
            MoveComponent.Compose(canMove);

            var canRotate = new AtomicAnd();
            canRotate.Append(LifeComponent.IsAlive);
            RotationComponent.Compose(canRotate);

            MoveMechanics = new(MoveComponent.Speed, MoveComponent.MoveDirection, MoveComponent.Root, MoveComponent.CanMove);

            var myPos = new AtomicFunction<Vector3>(() => MoveComponent.Root.Value.position);
            TargetDetectionMechanics = new(DetectionRadius, myPos, _target, _playerLayer);

            var playerPos = new AtomicFunction<Vector3>(() => _target.Value.transform.position);
            var hasTarget = new AtomicFunction<bool>(() => _target.Value != null);
            var lookAtTargetEnabled = new AtomicAnd();
            lookAtTargetEnabled.Append(LifeComponent.IsAlive);
            lookAtTargetEnabled.Append(hasTarget);
            LookAtTargetMechanics = new(RotationComponent.RotateAction, playerPos, myPos, lookAtTargetEnabled);

            var chaseTargetEnabled = new AtomicAnd();
            chaseTargetEnabled.Append(LifeComponent.IsAlive);
            chaseTargetEnabled.Append(hasTarget);
            ChaseTargetMechanics = new(myPos, playerPos, StoppingDistance, chaseTargetEnabled, MoveComponent.MoveDirection);

            AttackComponent.Compose(attackStartEvent, attackEndEvent);
            AttackComponent.CanAttack.Append(LifeComponent.IsAlive);
            AttackComponent.CanAttack.Append(hasTarget);
            attackStartEvent.Subscribe(() =>
            {
                if (AttackComponent.ReloadTimer.Value <= 0)
                {
                    AttackComponent.ReloadTimer.Value = AttackComponent.AttackCooldown;
                }
            });
            CooldownMechanics = new CooldownMechanics(AttackComponent.ReloadTimer);
        }
    }
}