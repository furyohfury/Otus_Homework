using Atomic.Elements;
using Atomic.Entities;
using Unity.VisualScripting;
using UnityEngine;

namespace Game
{
	public class DestructibleWallInstaller : SceneEntityInstallerBase
	{
		[Header("Config")] [SerializeField]
		private Vector2 _velocityToDestroy;

		[Header("FX")] [SerializeField]
		private ParticleSystem _explosionEffect;
		[SerializeField]
		private AudioClip _explosionSound;
		[SerializeField] [Range(0.0f, 1.0f)]
		private float _explosionVolume = 1.0f;

		[SerializeField]
		private Transform _transform;
		[SerializeField]
		private CollisionReceiver _collisionReceiver;
		[SerializeField]
		private TriggerReceiver _triggerReceiver;

		private Vector2 _cachedVelocity;
		
		public override void Install(IEntity entity)
		{
			if (_explosionEffect != null)
			{
				var effectMain = _explosionEffect.main;
				effectMain.stopAction = ParticleSystemStopAction.Destroy;
			}

			var destroyEvent = new BaseEvent();
			destroyEvent.Subscribe(DestroyWall);
			entity.AddDestroyEvent(destroyEvent);

			_triggerReceiver.OnTriggerEnter += OnTriggerred;
			_collisionReceiver.OnCollisionEnter += OnCollided;
		}

		private void OnTriggerred(Collider2D other)
		{
			if (other.TryGetEntity(out IEntity entity) && entity.TryGetRigidbody(out Rigidbody2D rigidbody2D))
			{
				_cachedVelocity = rigidbody2D.velocity;
			}
		}

		private void DestroyWall()
		{
			if (_explosionEffect != null)
			{
				var effect = Instantiate(_explosionEffect, _transform.position, Quaternion.identity);

				if (_explosionSound != null)
				{
					effect.AddComponent<AudioSource>().PlayOneShot(_explosionSound, _explosionVolume);
				}
			}

			Destroy(_transform.gameObject);
		}

		private void OnCollided(Collision2D collision2D)
		{
			if (!collision2D.TryGetEntity(out IEntity collisionEntity)
			    || !collisionEntity.TryGetRigidbody(out Rigidbody2D collisionRb))
			{
				return;
			}

			if (CanDestroy(collision2D.relativeVelocity))
			{
				collisionRb.velocity = _cachedVelocity;
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

		private void OnValidate()
		{
			if (_velocityToDestroy.x != 0 && _velocityToDestroy.y != 0)
			{
				_velocityToDestroy = Vector2.zero;
				Debug.LogError("Wall can be destroyed only by velocity from one side");
			}
		}
	}
}