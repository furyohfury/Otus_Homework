using UnityEngine;

namespace ShootEmUp
{
    public sealed class CharacterController : MonoBehaviour, IDamagable
    {
        public event Action OnCharacterDeath;

        [SerializeField] private HitPointsComponent _hpComponent; // needs to be serializable?

        [SerializeField] private WeaponComponent _weaponComponent;
        [SerializeField] private GameManager gameManager;
        [SerializeField] private BulletSystem _bulletSystem;
        [SerializeField] private BulletConfig _bulletConfig;
        
        public bool _fireRequired;

        private void OnEnable()
        {
            _hpComponent.hpEmpty += OnCharacterDeath;
        }

        private void OnDisable()
        {
            _hpComponent.hpEmpty -= OnCharacterDeath;
        }
        private void OnValidate()
        {
            this.gameObject.layer = (int)PhysicsLayer.CHARACTER;
        }

        private void FixedUpdate()
        {
            if (this._fireRequired)
            {
                this.OnFlyBullet();
                this._fireRequired = false;
            }
        }

        private void OnFlyBullet()
        {
            _bulletSystem.FireBullet(new BulletArgs
            {
                isPlayer = true,
                physicsLayer = (int) this._bulletConfig.physicsLayer,
                color = this._bulletConfig.color,
                damage = this._bulletConfig.damage,
                position = _weaponComponent.Position,
                velocity = _weaponComponent.Rotation * Vector3.up * this._bulletConfig.speed
            });
        }

        public void TakeDamage(int damage)
        {
            _hpComponent.TakeDamage(damage);
        }
    }
}