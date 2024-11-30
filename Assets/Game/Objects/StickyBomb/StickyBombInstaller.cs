using System;
using Atomic.Elements;
using Atomic.Entities;
using R3;
using Unity.VisualScripting;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Game
{
	public class StickyBombInstaller : IEntityInstaller
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
		private AudioClip _stickingSound;
		[SerializeField]
		private ParticleSystem _explosionEffect;
		[SerializeField]
		private AudioClip _explosionSound;
		[SerializeField] [Range(0.0f, 1.0f)]
		private float _explosionVolume = 1.0f;

		[SerializeField]
		private Rigidbody2D _rigidbody;
		[SerializeField]
		private Transform _transform;
		[SerializeField]
		private TriggerReceiver _triggerReceiver;

		private CompositeDisposable _disposable = new();
		
		public void Install(IEntity entity)
		{
			if (_explosionEffect != null)
			{
				var effectMain = _explosionEffect.main;
				effectMain.stopAction = ParticleSystemStopAction.Destroy;
			}

			_triggerReceiver.OnTriggerEnter += OnCollisionEnter;
		}

		private void OnCollisionEnter(Collider2D collider2D)
		{
			_rigidbody.simulated = false;
			Observable
				.Timer(TimeSpan.FromSeconds(_explosionDelay))
				.Subscribe(_ => Explode())
				.AddTo(_disposable);
		}

		private void Explode()
		{
			if (_explosionEffect != null)
			{
				var effect = Object.Instantiate(_explosionEffect, _transform.position, Quaternion.identity);

				if (_explosionSound != null)
				{
					effect.AddComponent<AudioSource>().PlayOneShot(_explosionSound, _explosionVolume);
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
					rb.AddExplosionForce2D(_explosionForce,
						_transform.position,
						_explosionRadius,
						_explosionUpwardForce);
					// TODO check if works on bullets
				}

				Timer<float> a = new();

				if (entity.TryGetDestroyEvent(out var destroyEvent)) // TODO mb wall tag
				{
					destroyEvent.Invoke();
				}

				if (!entity.HasCharacterTag() && entity.TryGetTakeDamageRequest(out var request))
				{
					request.Invoke(_explosionDamage);
				}
			}
			
			_disposable.Clear();
			Object.Destroy(_transform.gameObject);
		}
	}
}