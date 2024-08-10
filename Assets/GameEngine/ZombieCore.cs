using System;
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

        [ShowInInspector, ReadOnly]
        private readonly AtomicVariable<GameObject> _target = new();
        public AtomicVariable<float> Radius;
        public AtomicVariable<LayerMask> _playerLayer;

        public MoveMechanics MoveMechanics;
        public TargetDetectionMechanics TargetDetectionMechanics;
        public LookAtTargetMechanics LookAtTargetMechanics;

        public void Compose()
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
            TargetDetectionMechanics = new(Radius, myPos, _target, _playerLayer);
            var playerPos = new AtomicFunction<Vector3>(() => _target.Value.transform.position);
            var lookAtTargetEnabled = new AtomicAnd();
            lookAtTargetEnabled.Append(LifeComponent.IsAlive);
            lookAtTargetEnabled.Append(new AtomicFunction<bool>(() => _target.Value != null));
            LookAtTargetMechanics = new(RotationComponent.RotateAction, playerPos, myPos, lookAtTargetEnabled);
        }
    }
}