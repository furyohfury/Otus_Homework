using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game
{
	public sealed class DeathSFXBehaviour : IEntityInit, IEntityDispose
	{
		private AudioClip[] _deathSounds;
		private AudioSource _audioSource;
		private BaseEvent _deathEvent;

		public void Init(IEntity entity)
		{
			_deathSounds = entity.GetDeathSounds();
			_audioSource = entity.GetAudioSource();
			_deathEvent = entity.GetDeathEvent();
			_deathEvent.Subscribe(OnDeathEvent);
		}

		private void OnDeathEvent()
		{
			_audioSource.Stop();
			_audioSource.PlayOneShot(_deathSounds[Random.Range(0, _deathSounds.Length - 1)]);
		}

		public void Dispose(IEntity entity)
		{
			_deathEvent.Unsubscribe(OnDeathEvent);
		}
	}
}