using System;
using Atomic.Elements;
using UnityEngine;

namespace GameEngine
{
    [Serializable]
    public sealed class CharacterCore
    {
        // Components
        [SerializeField]
        public MoveComponent MoveComponent;
        [SerializeField]
        public RotationComponent RotationComponent;
        [SerializeField]
        public LifeComponent LifeComponent;

        // Data
        private Vector3 CursorPosition;

        public MoveMechanics MoveMechanics;
        public LookAtTargetMechanics LookAtTargetMechanics;
        public RotateMechanics RotateMechanics;

        public void Compose(Camera camera)
        {
            LifeComponent.Compose();            

            var canMove = new AtomicAnd();
            canMove.Append(LifeComponent.IsAlive);
            MoveComponent.Compose(canMove);

            var canRotate = new AtomicAnd();
            canRotate.Append(LifeComponent.IsAlive);            
            RotationComponent.Compose(canRotate);

            MoveMechanics = new(MoveComponent.Speed, MoveComponent.MoveDirection, MoveComponent._rigidBody, MoveComponent.CanMove);
            RotateMechanics = new(RotationComponent.RotateAction, RotationComponent.RotateRate, RotationComponent.RotationRoot, RotationComponent.CanRotate);

            var rotRoot = new AtomicFunction<Vector3>(() => RotationComponent.RotationRoot.position);
            var cursorPos = new AtomicFunction<Vector3>(() =>
            {
                var screenPos = Input.mousePosition;
                screenPos = new(screenPos.x, screenPos.y, (camera.transform.position - rotRoot.Value).magnitude);
                var worldPos = camera.ScreenToWorldPoint(screenPos);
                worldPos.y = RotationComponent.RotationRoot.position.y;
                return worldPos;
            });
            LookAtTargetMechanics = new(RotationComponent.RotateAction, cursorPos, rotRoot, RotationComponent.CanRotate);
        }
    }
}
