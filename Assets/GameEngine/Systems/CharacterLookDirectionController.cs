using Atomic.Extensions;
using Atomic.Objects;
using UnityEngine;
using Zenject;

namespace GameEngine
{
    public sealed class CharacterLookDirectionController : ITickable
    {
        private readonly IAtomicEntity _character;
        private readonly Camera _camera;

        public CharacterLookDirectionController(IAtomicEntity player, Camera camera)
        {
            _character = player;
            _camera = camera;
        }

        void ITickable.Tick()
        {
            var screenPos = Input.mousePosition;
            var playerPos = _character.GetValue<Vector3>(PositionAPI.ROOT_POSITION).Value;
            screenPos = new(screenPos.x, screenPos.y, (_camera.transform.position - playerPos).magnitude);

            var worldPos = _camera.ScreenToWorldPoint(screenPos);
            _character.GetVariable<Vector3>(RotateAPI.LOOK_DIRECTION).Value = worldPos;
        }
    }
}
