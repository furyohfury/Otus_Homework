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

        public LookAtTargetMechanics LookAtTargetMechanics;

        public void Compose(Camera camera)
        {
            var canMove = new AtomicAnd();
            canMove.Append(LifeComponent.IsAlive);
            MoveComponent.Compose(canMove);

            var canRotate = new AtomicAnd();
            canRotate.Append(LifeComponent.IsAlive);
            RotationComponent.Compose(canRotate);

            var rotRoot = new AtomicFunction<Vector3>(() => RotationComponent.RotationRoot.position);
            var cursorPos = new AtomicFunction<Vector3>(() =>
            {
                var screenPos = Input.mousePosition;
                screenPos = new(screenPos.x, screenPos.y, (camera.transform.position - rotRoot.Value).magnitude);
                var worldPos = camera.ScreenToWorldPoint(screenPos);
                worldPos.y = RotationComponent.RotationRoot.position.y;
                return worldPos;
            });

            LifeComponent.Compose();

            LookAtTargetMechanics = new(RotationComponent.RotateAction, cursorPos, rotRoot, RotationComponent.CanRotate);
        }
    }
}
