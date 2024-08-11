using System;
using Atomic.Elements;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GameEngine
{
    [Serializable]
    public class ZombieCore
    {
        [TitleGroup("Components", alignment: TitleAlignments.Centered, boldTitle: true)]
        public LifeComponent LifeComponent;
        [TitleGroup("Components")]
        public MoveComponent MoveComponent;
        [SerializeField, TitleGroup("Components")]
        private RotationComponent _rotationComponent;
        [TitleGroup("Components")]
        public AttackComponent AttackComponent;

        [ShowInInspector, ReadOnly, Space]
        private readonly AtomicVariable<GameObject> _target = new();
        [TitleGroup("Separate variables", alignment: TitleAlignments.Centered, boldTitle: true)]
        public AtomicVariable<float> DetectionRadius;
        [TitleGroup("Separate variables")]
        public AtomicVariable<float> StoppingDistance;
        [SerializeField, TitleGroup("Separate variables")]
        private AtomicVariable<LayerMask> _playerLayer;
        [SerializeField, TitleGroup("Separate variables")]
        private AtomicVariable<Rigidbody> _root;

        public MoveMechanics MoveMechanics;
        public TargetDetectionMechanics TargetDetectionMechanics;
        public LookAtTargetMechanics LookAtTargetMechanics;
        public ChaseTargetMechanics ChaseTargetMechanics;
        public CooldownMechanics CooldownMechanics;

        public void Compose()
        {
            LifeComponent.Compose();

            var canMove = new AtomicAnd();
            canMove.Append(LifeComponent.IsAlive);
            MoveComponent.Compose(canMove);

            var canRotate = new AtomicAnd();
            canRotate.Append(LifeComponent.IsAlive);
            _rotationComponent.Compose(_root, canRotate);

            MoveMechanics = new(MoveComponent.Speed, MoveComponent.MoveDirection, _root, MoveComponent.CanMove);

            var myPos = new AtomicFunction<Vector3>(() => _root.Value.position);
            TargetDetectionMechanics = new(DetectionRadius, myPos, _target, _playerLayer);

            var playerPos = new AtomicFunction<Vector3>(() => _target.Value.transform.position);
            var hasTarget = new AtomicFunction<bool>(() => _target.Value != null);
            var lookAtTargetEnabled = new AtomicAnd();
            lookAtTargetEnabled.Append(LifeComponent.IsAlive);
            lookAtTargetEnabled.Append(_rotationComponent.CanRotate);
            lookAtTargetEnabled.Append(hasTarget);
            LookAtTargetMechanics = new(_rotationComponent.RotateAction, playerPos, myPos, lookAtTargetEnabled);

            var chaseTargetEnabled = new AtomicAnd();
            chaseTargetEnabled.Append(LifeComponent.IsAlive);
            chaseTargetEnabled.Append(hasTarget);
            ChaseTargetMechanics = new(myPos, playerPos, StoppingDistance, chaseTargetEnabled, MoveComponent.MoveDirection);

            ChaseTargetMechanics.ReachedTargetEvent.Subscribe(AttackComponent.AttackRequest.Invoke);

            AttackComponent.Compose();
            AttackComponent.CanAttack.Append(LifeComponent.IsAlive);
            AttackComponent.CanAttack.Append(hasTarget);
            CooldownMechanics = new CooldownMechanics(AttackComponent.ReloadTimer);
        }
    }
}