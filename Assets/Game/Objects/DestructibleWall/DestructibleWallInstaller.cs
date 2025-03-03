using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game
{
	public class DestructibleWallInstaller : SceneEntityInstallerBase
	{
		[Header("Config")] [SerializeField]
		private Vector2 _velocityToDestroy;

		[Header("VFX")] [SerializeField]
		private ParticleSystem _explosionEffect;
		[Header("SFX")] [SerializeField]
		private AudioSource _audioSource;
		[SerializeField]
		private AudioClip _explosionSound;
		[SerializeField] [Range(0.0f, 1.0f)]
		private float _explosionVolume = 1.0f;

		[Header("Components")] [SerializeField]
		private SpriteRenderer _spriteRenderer;
		[SerializeField]
		private Transform _transform;
		[SerializeField]
		private CollisionReceiver _collisionReceiver;
		[SerializeField]
		private TriggerReceiver _triggerReceiver;
		[SerializeField] 
		private Collider2D _collider;

		private IEntity _entity;
		private Vector2 _cachedVelocity;
		private bool _broken;

		public override void Install(IEntity entity)
		{
			_entity = entity;
			entity.AddTag(TagAPI.DestructibleWall);

			entity.AddVisualTransform(_transform);
			
			var destroyEvent = new BaseEvent();
			destroyEvent.Subscribe(DestroyWall);
			entity.AddDestroyEvent(destroyEvent);

			_triggerReceiver.OnTriggerEnter += OnTriggerred;
			_collisionReceiver.OnCollisionEnter += OnCollided;
		}

		private void OnTriggerred(Collider2D other)
		{
			if (other.TryGetEntity(out IEntity entity)
			    && entity.TryGetRigidbody2D(out Rigidbody2D rigidbody2D))
			{
				_cachedVelocity = rigidbody2D.velocity;
			}
		}

		private void OnCollided(Collision2D collision2D)
		{
			if (_broken
				|| !collision2D.TryGetEntity(out IEntity collisionEntity)
			    || !collisionEntity.TryGetRigidbody2D(out Rigidbody2D collisionRb))
			{
				return;
			}

			if (CanDestroy(collision2D.relativeVelocity))
			{
				_broken = true;
				collisionRb.velocity = _cachedVelocity;
				_collider.enabled = false;
				DestroyWall();
			}
		}

		private bool CanDestroy(Vector2 velocity)
		{
			if (_velocityToDestroy.x > 0)
			{
				return Mathf.Abs(velocity.x) > _velocityToDestroy.x;
			}

			return Mathf.Abs(velocity.y) > _velocityToDestroy.y;
		}

		private void DestroyWall()
		{
			_spriteRenderer.enabled = false;
			_explosionEffect.Play();
			_audioSource.PlayOneShot(_explosionSound, _explosionVolume);
			var timer = new Timer(_explosionSound.length);
			_entity.WhenUpdate(timer.Tick);
			timer.Start();
			timer.OnEnded += Destroy;
		}

		private void Destroy()
		{
			SceneEntity.Destroy(_entity);
		}

#if UNITY_EDITOR
		private void OnValidate()
		{
			if (_velocityToDestroy.x != 0 && _velocityToDestroy.y != 0)
			{
				_velocityToDestroy = Vector2.zero;
				Debug.LogError("Wall can be destroyed only by velocity from one side");
			}
		}
#endif
	}
}