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

		public void Init(IEntity entity)
		{
			_deathSounds = entity.GetDeathSounds();
			_audioSource = entity.GetAudioSource();
			_deathRequest = entity.GetDeathRequest();
			_deathRequest.Subscribe(OnDeathRequest);
		}

		private void OnDeathRequest()
		{
			_audioSource.Stop();
			var randomSound = _deathSounds[Random.Range(0, _deathSounds.Length)];
			_audioSource.PlayOneShot(randomSound);
		}

		public void Dispose(IEntity entity)
		{
			_deathRequest.Unsubscribe(OnDeathRequest);
		}
	}
}