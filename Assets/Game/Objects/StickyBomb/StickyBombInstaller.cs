using System;
using Atomic.Entities;
using Unity.VisualScripting;
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
		[SerializeField]
		private ParticleSystem _explosionEffect;
		[SerializeField]
		private AudioClip _timerSound;
		[SerializeField]
		private AudioClip _explosionSound;
		[SerializeField] [Range(0.0f, 1.0f)]
		private float _soundVolume = 1.0f;

		[SerializeField]
		private Rigidbody2D _rigidbody;
		[SerializeField]
		private Transform _transform;
		[SerializeField]
		private TriggerReceiver _triggerReceiver;

		private IEntity _entity;
		private AudioSource _effectsContainer;

		public override void Install(IEntity entity)
		{
			_entity = entity;
			entity.AddRigidbody(_rigidbody);
			if (_explosionEffect != null)
			{
				var effectMain = _explosionEffect.main;
				effectMain.stopAction = ParticleSystemStopAction.Destroy;
			}

			_triggerReceiver.OnTriggerEnter += OnCollided;
		}

		private void OnCollided(Collider2D _)
		{
			_rigidbody.simulated = false;
			var timer = new Timer(_explosionDelay);
			timer.Start();
			_entity.WhenUpdate(timer.Tick);
			timer.OnEnded += Explode;
			var effectsGo = new GameObject
			                {
				                transform =
				                {
					                position = transform.position, rotation = Quaternion.identity
				                }
			                };
			_effectsContainer = effectsGo.AddComponent<AudioSource>();
			if (_timerSound != null)
			{
				_effectsContainer.PlayOneShot(_timerSound);
			}
		}

		private void Explode()
		{
			if (_explosionEffect != null)
			{
				var explosionEffect = Instantiate(_explosionEffect, _transform.position, Quaternion.identity, _effectsContainer.transform);
				var particleSystemMain = explosionEffect.main;
				particleSystemMain.stopAction = ParticleSystemStopAction.Destroy;
				
				if (_explosionSound != null)
				{
					_effectsContainer.PlayOneShot(_explosionSound, _soundVolume);
				}
			}

			var colliders = Physics2D.OverlapCircleAll(_transform.position, _explosionRadius);
			foreach (var hit in colliders)
			{
				if (!hit.TryGetEntity(out IEntity entity))
				{
					continue;
				}

				if (entity.TryGetRigidbody(out Rigidbody2D rb))
				{
					rb.velocity = new Vector2(rb.velocity.x, 0);
					rb.AddExplosionForce2D(_explosionForce,
						_transform.position,
						_explosionRadius,
						_explosionUpwardForce);
				}

				if (entity.TryGetDestroyEvent(out var destroyEvent)) // TODO mb wall tag
				{
					destroyEvent.Invoke();
				}

				if (!entity.HasCharacterTag() && entity.TryGetTakeDamageRequest(out var request))
				{
					request.Invoke(_explosionDamage);
				}
			}

			gameObject.SetActive(false);
		}

#if UNITY_EDITOR
		private void OnDrawGizmos()
		{
			Gizmos.color = Color.red;
			Gizmos.DrawSphere(transform.position, _explosionRadius);
		}

		private void OnValidate()
		{
			if (_timerSound != null && Mathf.Abs(_explosionDelay - _timerSound.length) > 0.1)
			{
				Debug.LogWarning($"Installed delay and sound of it on sticky bomb are too different. Division is {_explosionDelay - _timerSound.length}");
			}
		}
#endif
	}
}