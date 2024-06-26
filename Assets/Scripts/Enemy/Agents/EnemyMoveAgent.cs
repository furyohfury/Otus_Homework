using System;
using UnityEngine;

namespace ShootEmUp
{
    [Serializable]
    public sealed class EnemyMoveAgent : IOnFixedUpdateListener
    {
        public event Action OnReachedDestination;

        [SerializeField] private MoveComponent _moveComponent;

        private Vector2? _destination;

        public void Init()
        {
            IGameStateListener.Register(this);
        }

        public void SetDestination(Vector2 endPoint) => _destination = endPoint;

        void IOnFixedUpdateListener.OnFixedUpdate(float deltaTime)
        {
            if (_destination == null)
                return;

            Vector2 distance = (Vector2)(_destination - _moveComponent.GetPosition);
            if (distance.magnitude <= 0.05f)
            {
                OnReachedDestination?.Invoke();
                _destination = null;
            }
            else
            {
                distance.Normalize();
                _moveComponent.MoveByRigidbodyVelocity(distance * Time.fixedDeltaTime);
            }
        }
    }
}