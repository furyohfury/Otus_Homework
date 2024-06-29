using System;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class Bullet : MonoBehaviour
    {
        public int Damage { get; private set; }
        public Vector2 Velocity => _rigidbody2D.velocity;

        [SerializeField] private Rigidbody2D _rigidbody2D;
        [SerializeField] private SpriteRenderer spriteRenderer;

        public void SetDamage(int damage) => Damage = damage;

        public void SetVelocity(Vector2 velocity) => _rigidbody2D.velocity = velocity;

        public void SetPhysicsLayer(int physicsLayer) => gameObject.layer = physicsLayer;

        public void SetPosition(Vector3 position) => transform.position = position;

        public void SetColor(Color color) => spriteRenderer.color = color;

        public void SetParent(Transform parent) => transform.SetParent(parent);
    }
}