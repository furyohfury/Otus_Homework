using Atomic.Elements;
using Atomic.Entities;
using Unity.VisualScripting;
using UnityEngine;

namespace Game
{
	public class DestructibleWallInstaller : IEntityInstaller
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

		public void Install(IEntity entity)
		{
			if (_explosionEffect != null)
			{
				var effectMain = _explosionEffect.main;
				effectMain.stopAction = ParticleSystemStopAction.Destroy;
			}

			var destroyEvent = new BaseEvent();
			destroyEvent.Subscribe(DestroyWall);
			entity.AddDestroyEvent(destroyEvent);

			_collisionReceiver.OnCollisionEnter += OnCollision2DEnter;
		}

		private void DestroyWall()
		{
			if (_explosionEffect != null)
			{
				var effect = Object.Instantiate(_explosionEffect, _transform.position, Quaternion.identity);

				if (_explosionSound != null)
				{
					effect.AddComponent<AudioSource>().PlayOneShot(_explosionSound, _explosionVolume);
				}
			}

			Object.Destroy(_transform.gameObject);
		}

		private void OnCollision2DEnter(Collision2D collision)
		{
			if (!collision.TryGetEntity(out IEntity entity)
			    || !entity.TryGetRigidbody(out Rigidbody2D rigidbody))
			{
				return;
			}

			if (CanDestroy(rigidbody.velocity))
			{
				DestroyWall();
			}
		}

		private bool CanDestroy(Vector2 velocity)
		{
			if ((_velocityToDestroy.x > 0 && velocity.x > _velocityToDestroy.x)
			    || (_velocityToDestroy.y > 0 && velocity.y > _velocityToDestroy.y))
			{
				return true;
			}

			return false;
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