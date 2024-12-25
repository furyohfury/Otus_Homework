using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game
{
	public sealed class ShootSFXWeaponBehaviour : IEntityInit, IEntityDispose
	{
		private BaseEvent _attackEvent;
		private AudioSource _audioSource;
		private AudioClip _shootAudioClip;

		public void Init(IEntity entity)
		{
			_audioSource = entity.GetAudioSource();
			_shootAudioClip = entity.GetShootAudioClip();
			_attackEvent = entity.GetAttackEvent();
			_attackEvent.Subscribe(OnWeaponShoot);
		}

		private void OnWeaponShoot()
		{
			_audioSource.clip = _shootAudioClip;
			_audioSource.Play();
			// TODO last sound cant be played cuz of destroy. Mb check ammo and create oneshot GO
		}

		public void Dispose(IEntity entity)
		{
			_attackEvent.Unsubscribe(OnWeaponShoot);
		}
	}
}