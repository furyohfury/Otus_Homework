using UnityEngine;

namespace GameEngine
{
    public sealed class CameraComponent : MonoBehaviour
    {
        [SerializeField]
        private Transform _target;
        private Vector3 _offset;

        private void Start()
        {
            _offset = _target.position - transform.position;
        }

        private void LateUpdate()
        {
            transform.position = _target.position - _offset;
        }
    }
}
