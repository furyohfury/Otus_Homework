using UnityEngine;
using Zenject;

namespace GameEngine
{
    public sealed class CameraComponent : IInitializable, ILateTickable
    {
        private Vector3 _offset;
        private readonly Transform _target;
        private readonly Camera _camera;

        public CameraComponent(Transform target, Camera camera)
        {
            _target = target;
            _camera = camera;
        }

        void IInitializable.Initialize()
        {
            _offset = _target.position - _camera.transform.position;
        }

        void ILateTickable.LateTick()
        {
            _camera.transform.position = _target.position - _offset;
        }
    }
}
