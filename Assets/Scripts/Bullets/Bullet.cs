using System;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class Bullet : MonoBehaviour, IGamePauseListener, 
    IGameResumeListener, IGameFinishListener
    {
        public event Action<Bullet, Collision2D> OnCollisionEntered;

        public int Damage { get; private set; }

        [SerializeField]
        private Rigidbody2D rigidbody2D;

        private Vector2 _velocity;

        [SerializeField]
        private SpriteRenderer spriteRenderer;

        private void Awake()
        {
            IGameStateListener.Register(this);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            OnCollisionEntered?.Invoke(this, collision);
        }

        public void SetDamage(int damage)
        {
            this.Damage = damage;
        }

        public void SetVelocity(Vector2 velocity)
        {
            rigidbody2D.velocity = velocity;
        }

        public void SetPhysicsLayer(int physicsLayer)
        {
            gameObject.layer = physicsLayer;
        }

        public void SetPosition(Vector3 position)
        {
            transform.position = position;
        }

        public void SetColor(Color color)
        {
            spriteRenderer.color = color;
        }

        public void SetParent(Transform parent)
        {
            transform.SetParent(parent);
        }

        public void PauseGame()
        {
            _velocity = _rigidbody2D.velocity;
            SetVelocity(Vector2.zero);
        }

        public void ResumeGame()
        {
            SetVelocity(_velocity);
        }

        public void FinishGame()
        {
            SetVelocity(Vector2.zero);
        }
    }
}