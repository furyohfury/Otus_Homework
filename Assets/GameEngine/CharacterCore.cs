using System;
using Atomic.Elements;
using Atomic.Extensions;
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
        
        public LookAtTargetMechanics LookAtTargetMechanics;

        public void Compose(Camera camera)
        {
            MoveComponent.Compose();

            RotationComponent.Compose(new AtomicAnd());
            
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
