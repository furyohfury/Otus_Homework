using UnityEngine;

namespace ShootEmUp
{
    public sealed class MoveComponent : MonoBehaviour
    {
        [Title("Values")]
        [SerializeField] private float _speed = 5.0f;

        [Title("References")]
        [SerializeField] private Rigidbody2D _rigidbody2D;        

        public void MoveByRigidbodyVelocity(Vector2 velocity)
        {
            var nextPosition = _rigidBody2D.position + velocity * _speed;
            _rigidBody2D.MovePosition(nextPosition);
        }
    }
}