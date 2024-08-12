using System;
using Atomic.Elements;
using Atomic.Extensions;
using Atomic.Objects;
using UnityEngine;
using Zenject;

namespace GameEngine
{
    public sealed class CameraComponent : IInitializable, ILateTickable
    {
        private Vector3 _offset;
        private IAtomicValue<Vector3> _targetPos;
        private readonly Camera _camera;
        private readonly IAtomicEntity _target;

        public CameraComponent(IAtomicEntity target, Camera camera)
        {
            _target = target;
            _camera = camera;
        }

        void IInitializable.Initialize()
        {
            if (_target.TryGetValue<Vector3>(PositionAPI.ROOT_POSITION, out var pos))
            {
                _offset = pos.Value - _camera.transform.position;
                _targetPos = pos;
            }
            else
            {
                throw new Exception("Camera component didnt find player root");
            }
        }

        void ILateTickable.LateTick()
        {
            _camera.transform.position = _targetPos.Value - _offset; // todo fix
        }
    }
}
