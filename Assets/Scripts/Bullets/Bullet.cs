using System;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class Bullet : MonoBehaviour
    {
        public event Action<Bullet, Collision2D> OnCollisionEntered;

        private bool isPlayer; //todo what is this field
        private int damage;

        [SerializeField]
        private new Rigidbody2D rigidbody2D;

        [SerializeField]
        private SpriteRenderer spriteRenderer;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.TryGetComponent(out IDamagable damagable))
            {
                IDamagable.TakeDamage(bullet.damage);
            }
            this.OnCollisionEntered?.Invoke(this, collision);
        }

        public void SetDamage(int damage)
        {
            this.damage = damage;
        }

        public void SetIsPlayer(bool v)
        {
            isPlayer = v;
        }

        public void SetVelocity(Vector2 velocity)
        {
            this.rigidbody2D.velocity = velocity;
        }

        public void SetPhysicsLayer(int physicsLayer)
        {
            this.gameObject.layer = physicsLayer;
        }

        public void SetPosition(Vector3 position)
        {
            this.transform.position = position;
        }

        public void SetColor(Color color)
        {
            this.spriteRenderer.color = color;
        }
    }
}