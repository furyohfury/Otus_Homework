using Atomic.Extensions;
using Atomic.Objects;
using UnityEngine;
using Zenject;

namespace GameEngine
{
    public sealed class PlayerLookDirectionController : ITickable
    {
        private readonly IAtomicEntity _player;
        private readonly Camera _camera;

        public PlayerLookDirectionController(IAtomicEntity player, Camera camera)
        {
            _player = player;
            _camera = camera;
        }

        void ITickable.Tick()
        {
            var screenPos = Input.mousePosition;
            var playerPos = _player.GetValue<Vector3>("RootPosition").Value;
            screenPos = new(screenPos.x, screenPos.y, (_camera.transform.position - playerPos).magnitude);

            var worldPos = _camera.ScreenToWorldPoint(screenPos);
            _player.GetVariable<Vector3>("LookDirection").Value = worldPos;
        }
    }
}
