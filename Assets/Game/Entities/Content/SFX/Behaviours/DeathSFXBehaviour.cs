using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game
{
	public sealed class DeathSFXBehaviour : IEntityInit, IEntityDispose
	{
		private AudioClip[] _deathSounds;
		private AudioSource _audioSource;
		private IEvent _deathRequest;
		private IEntity _entity;
		private BaseEvent _deathEvent;

		public void Init(IEntity entity)
		{
			_entity = entity;
			_deathSounds = entity.GetDeathSounds();
			_audioSource = entity.GetAudioSource();
			_deathRequest = entity.GetDeathRequest();
			_deathRequest.Subscribe(OnDeathRequest);
			_deathEvent = entity.GetDeathEvent();
		}

		private void OnDeathRequest()
		{
			_audioSource.Stop();
			var randomSound = _deathSounds[Random.Range(0, _deathSounds.Length - 1)];
			_audioSource.PlayOneShot(randomSound);
		}

		private void OnDead()
		{
			_deathEvent.Invoke();
		}

		public void Dispose(IEntity entity)
		{
			_deathRequest.Unsubscribe(OnDeathRequest);
		}
	}
}