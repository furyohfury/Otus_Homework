using System;
using UnityEngine;

namespace ShootEmUp
{
    public class Enemy : MonoBehaviour, IHitPoints
    {
        public event Action<Enemy> OnDied;
        public event Action<BulletConfig, Vector2, Vector2> OnFire;

        public HitPointsComponent HitPointsComponent => _hitPointsComponent;

        [SerializeField] private HitPointsComponent _hitPointsComponent;
        [SerializeField] private EnemyAttackAgent _attackAgent;
        [SerializeField] private EnemyMoveAgent _moveAgent;

        private void Awake()
        {
            _attackAgent.OnFire += Fire;
            _hitPointsComponent.OnHPEnded += Die;
            _moveAgent.OnReachedDestination += ReachedDestination;
            _attackAgent.Init();
            _moveAgent.Init();
        }

        private void OnDestroy()
        {
            _attackAgent.OnFire -= Fire;
            _hitPointsComponent.OnHPEnded -= Die;
            _moveAgent.OnReachedDestination -= ReachedDestination;
        }

        public void SetPosition(Vector2 position) => transform.position = position;

        public void SetDestination(Vector2 endPoint)
        {
            _moveAgent.SetDestination(endPoint);
            _attackAgent.Active = false;
        }

        public void SetTarget(Transform target) => _attackAgent.SetTarget(target);

        public void SetParent(Transform parent) => transform.SetParent(parent);

        private void ReachedDestination() => _attackAgent.Active = true;

        private void Fire(BulletConfig config, Vector2 pos, Vector2 vel) => OnFire?.Invoke(config, pos, vel);

        private void Die() => OnDied?.Invoke(this);
    }
}