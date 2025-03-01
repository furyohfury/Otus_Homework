using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game
{
	public sealed class TakeDamageSFXBehaviour : IEntityInit, IEntityDispose
	{
		private AudioSource _audioSource;
		private AudioClip[] _takeDamageSounds;
		private BaseEvent<int> _takeDamageEvent;
		private ReactiveVariable<int> _health;

		public void Init(IEntity entity)
		{
			_audioSource = entity.GetAudioSource();
			_takeDamageSounds = entity.GetTakeDamageSounds();
			_health = entity.GetHealth();
			_takeDamageEvent = entity.GetTakeDamageEvent();
			_takeDamageEvent.Subscribe(OnTakeDamage);
		}

		private void OnTakeDamage(int _)
		{
			if (_health.Value > 0)
			{
				_audioSource.PlayOneShot(_takeDamageSounds[Random.Range(0, _takeDamageSounds.Length - 1)]);
			}
		}

		public void Dispose(IEntity entity)
		{
			_takeDamageEvent.Unsubscribe(OnTakeDamage);
		}
	}
}