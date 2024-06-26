using UnityEngine;

namespace ShootEmUp
{
    [System.Serializable]
    public sealed class MoveComponent
    {
        [SerializeField] private float _speed = 5.0f;

        [SerializeField] private Rigidbody2D _rigidbody2D;
        public Vector3 GetPosition => _rigidbody2D.position;

        public void MoveByRigidbodyVelocity(Vector2 velocity)
        {
            var nextPosition = _rigidbody2D.position + velocity * _speed;
            _rigidbody2D.MovePosition(nextPosition);
        }
    }
}