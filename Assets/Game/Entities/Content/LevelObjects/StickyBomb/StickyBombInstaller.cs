using Atomic.Elements;
using Atomic.Entities;
using Sirenix.OdinInspector;
using UnityEngine;
using Timer = Atomic.Elements.Timer;

namespace Game
{
	public class StickyBombInstaller : SceneEntityInstallerBase
	{
		[SerializeField]
		private int _explosionDamage = 5;

		[Header("Explosion Config")]
		[SerializeField]
		private float _explosionForce = 10.0f;
		[SerializeField]
		private float _explosionRadius = 10.0f;
		[SerializeField]
		private float _explosionDelay = 1f;
		[SerializeField]
		private float _explosionUpwardForce = 1.0f;


		[Header("FX")]
		[SerializeField] [Required]
		private ParticleSystem _explosionEffect;
		[SerializeField] [Required]
		private AudioClip _timerSound;
		[SerializeField] [Required]
		private AudioClip _explosionSound;
		[SerializeField] [Range(0.0f, 1.0f)]
		private float _soundVolume = 1.0f;

		[Header("Components")]
		[SerializeField]
		private Rigidbody2D _rigidbody;
		[SerializeField]
		private Transform _transform;
		[SerializeField]
		private TriggerReceiver _triggerReceiver;
		[SerializeField]
		private SpriteRenderer _spriteRenderer;
		[SerializeField]
		private AudioSource _audioSource;

		private IEntity _entity;
		private bool _isActivated;

		public override void Install(IEntity entity)
		{
			_entity = entity;
			entity.AddRigidbody2D(_rigidbody);
			_triggerReceiver.OnTriggerEnter += OnCollided;
		}

		private void OnCollided(Collider2D collision)
		{
			if (collision.isTrigger
			    || _isActivated)
			{
				return;
			}

			_isActivated = true;
			_rigidbody.simulated = false;
			var timer = new Timer(_explosionDelay);
			timer.Start();
			_entity.WhenUpdate(timer.Tick);
			_audioSource.PlayOneShot(_timerSound, _soundVolume);
			timer.OnEnded += Explode;
		}

		private void Explode()
		{
			ProcessCollisionsWithEntities();
			ProcessVisuals();
		}

		private void ProcessCollisionsWithEntities()
		{
			var colliders = Physics2D.OverlapCircleAll(_transform.position, _explosionRadius);
			foreach (var other in colliders)
			{
				if (!other.TryGetEntity(out IEntity otherEntity))
				{
					continue;
				}

				if (otherEntity.TryGetRigidbody2D(out Rigidbody2D rb))
				{
					rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0);
					rb.AddExplosionForce2D(_explosionForce,
						_transform.position,
						_explosionRadius,
						_explosionUpwardForce);
				}

				if (otherEntity.TryGetDestroyEvent(out BaseEvent destroyEvent))
				{
					destroyEvent.Invoke();
				}

				if (!otherEntity.HasCharacterTag() && otherEntity.TryGetTakeDamageRequest(out BaseEvent<int> request))
				{
					request.Invoke(_explosionDamage);
				}
			}
		}

		private void ProcessVisuals()
		{
			_spriteRenderer.enabled = false;
			_explosionEffect.Play();
			_audioSource.PlayOneShot(_explosionSound, _soundVolume);
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
		private void OnDrawGizmos()
		{
			Gizmos.color = Color.red;
			Gizmos.DrawWireSphere(transform.position, _explosionRadius);
		}

		private void OnValidate()
		{
			if (_timerSound != null && Mathf.Abs(_explosionDelay - _timerSound.length) > 0.1)
			{
				Debug.LogWarning(
					$"Installed delay and sound of it on sticky bomb are too different. Difference is {_explosionDelay - _timerSound.length}");
			}
		}
#endif
	}
}