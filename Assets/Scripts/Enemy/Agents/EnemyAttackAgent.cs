using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyAttackAgent : MonoBehaviour
    {
        public delegate void FireHandler(BulletConfig bulletConfig, Vector2 position, Vector2 velocity);

        public event FireHandler OnFire;

        [SerializeField] private WeaponComponent weaponComponent;
        [SerializeField] private EnemyMoveAgent moveAgent;
        [SerializeField] private float countdown;
        [SerializeField] private BulletConfig _bulletConfig;

        private GameObject target;
        private float currentTime;

        public void SetTarget(GameObject target)
        {
            this.target = target;
        }

        public void Reset()
        {
            this.currentTime = this.countdown;
        }

        private void FixedUpdate()
        {
            if (!this.moveAgent.IsReached)
            {
                return;
            }
            
            if (!this.target.GetComponent<HitPointsComponent>().IsHitPointsExists())
            {
                return;
            }

            this.currentTime -= Time.fixedDeltaTime;
            if (this.currentTime <= 0)
            {
                this.Fire();
                this.currentTime += this.countdown;
            }
        }

        private void Fire()
        {
            var startPosition = this.weaponComponent.Position;
            var vector = (Vector2) this.target.transform.position - startPosition;
            var direction = vector.normalized;
            this.OnFire?.Invoke(_bulletConfig, startPosition, direction * _bulletConfig.speed);
        }
    }
}