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
        private readonly Camera _camera;
        private readonly IAtomicEntity _target;
        private IAtomicFunction<Vector3> _rootPosition;

        public CameraComponent(IAtomicEntity target, Camera camera)
        {
            _target = target;
            _camera = camera;
        }

        void IInitializable.Initialize()
        {
            if (_target.TryGetFunction<Vector3>(PositionAPI.ROOT_POSITION, out IAtomicFunction<Vector3> pos))
            {
                _rootPosition = pos;
                _offset = _target.GetValue<Vector3>(PositionAPI.ROOT_POSITION).Value - _camera.transform.position;
            }
            else
            {
                throw new Exception("Camera component didnt find player root");
            }
        }

        void ILateTickable.LateTick()
        {
            _camera.transform.position = _rootPosition.Value - _offset; // todo fix
        }
    }
}
