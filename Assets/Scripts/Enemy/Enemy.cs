using System;
using UnityEngine;

namespace ShootEmUp
{
    public class Enemy : MonoBehaviour
    {
        public event Action OnDied;
        public event Action<BulletConfig, Vector2, Vector2> OnFire;

        [SerializeField] private EnemyAttackAgent _attackAgent;
        [SerializeField] private EnemyMoveAgent _moveAgent;
        [SerializeField] private HitPointsComponent _hitPointsComponent;

        private void OnEnable()
        {
            _attackAgent.OnFire += Fire;
            _hitPointsComponent.OnHPEnded += Die;
            _moveAgent.OnReachedDestination += ReachedDestination;
        }
        private void OnDisable()
        {
            _attackAgent.OnFire -= Fire;
            _hitPointsComponent.OnHPEnded -= Die;
            _moveAgent.OnReachedDestination -= ReachedDestination;
        }
        public void SetPosition(Vector2 position)
        {
            transform.position = position;
        }
        public void SetDestination(Vector2 endPoint)
        {
            _moveAgent.SetDestination(endPoint);
            _attackAgent.enabled = false;
        }

        public void SetTarget(Transform target)
        {
            _attackAgent.SetTarget(target);
        }

        public void SetParent(Transform parent)
        {
            transform.SetParent(parent);
        }

        private void ReachedDestination()
        {
            _attackAgent.enabled = true;
        }

        private void Fire(BulletConfig config, Vector2 pos, Vector2 vel)
        {
            OnFire?.Invoke(config, pos, vel);
        }

        private void Die()
        {
            OnDied?.Invoke();
        }
    }
}