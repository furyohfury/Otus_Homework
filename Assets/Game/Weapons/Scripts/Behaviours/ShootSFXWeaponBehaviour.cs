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
		private ReactiveVariable<int> _ammo;
		private ReactiveVariable<Transform> _firePoint;

		public void Init(IEntity entity)
		{
			_ammo = entity.GetAmmo();
			_firePoint = entity.GetFirePoint();
			_audioSource = entity.GetAudioSource();
			_shootAudioClip = entity.GetShootAudioClip();
			
			_attackEvent = entity.GetAttackEvent();
			_attackEvent.Subscribe(OnWeaponShoot);
		}

		private void OnWeaponShoot()
		{
			if (_ammo.Value > 1)
			{
				_audioSource.clip = _shootAudioClip;
				_audioSource.Play();
			}

			var source = new GameObject();
			source.transform.SetPositionAndRotation(_firePoint.Value.position, _firePoint.Value.rotation);
			// var audioSource = source.AddComponent<AudioSource>();
			// audioSource.clip = _shootAudioClip;
			// audioSource.volume = _audioSource.volume;
			// audioSource.Play(); // TODO destroy this thing somehow
			// TODO last sound cant be played cuz of destroy. Mb check ammo and create oneshot GO
		}

		public void Dispose(IEntity entity)
		{
			_attackEvent.Unsubscribe(OnWeaponShoot);
		}
	}
}