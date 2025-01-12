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
		private IValue<SceneEntity> _weapon;

		public void Init(IEntity entity)
		{
			_weapon = entity.GetWeapon();
			_audioSource = entity.GetAudioSource();
			_shootAudioClip = entity.GetShootAudioClip();
			_attackEvent = entity.GetAttackEvent();
			_attackEvent.Subscribe(OnWeaponShoot);
		}

		private void OnWeaponShoot()
		{
			if (_weapon.Value.GetAmmo().Value > 1)
			{
				_audioSource.clip = _shootAudioClip;
				_audioSource.Play();
			}

			Transform firePoint = _weapon.Value.GetFirePoint().Value;
			var source = new GameObject();
			var audioSource = source.AddComponent<AudioSource>();
			audioSource.clip = _shootAudioClip;
			audioSource.volume = _audioSource.volume;
			audioSource.Play(); // TODO destroy this thing somehow
			// TODO last sound cant be played cuz of destroy. Mb check ammo and create oneshot GO
		}

		public void Dispose(IEntity entity)
		{
			_attackEvent.Unsubscribe(OnWeaponShoot);
		}
	}
}