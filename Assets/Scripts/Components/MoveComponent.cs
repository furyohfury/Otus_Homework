using UnityEngine;

namespace ShootEmUp
{
    public sealed class MoveComponent : MonoBehaviour
    {
        [SerializeField] private float _speed = 5.0f;

        [SerializeField] private Rigidbody2D _rigidbody2D;

        public void MoveByRigidbodyVelocity(Vector2 velocity)
        {
            var nextPosition = _rigidbody2D.position + velocity * _speed;
            _rigidbody2D.MovePosition(nextPosition);
        }
    }
}