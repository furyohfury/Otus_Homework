using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game
{
	public sealed class ShootSFXWeaponBehaviour : IEntityInit, IEntityDispose
	{
		private IEntity _self;
		private BaseEvent _attackEvent;
		private AudioSource _audioSource;
		private AudioClip _shootAudioClip;
		private Transform _soundSpawnPoint;

		public void Init(IEntity entity)
		{
			_self = entity;
			_soundSpawnPoint = entity.TryGetFirePoint(out var firePoint)
				? firePoint.Value
				: entity.GetVisualTransform();

			_audioSource = entity.GetAudioSource();
			_shootAudioClip = entity.GetShootAudioClip();

			_attackEvent = entity.GetAttackEvent();
			_attackEvent.Subscribe(OnWeaponShoot);
		}

		private void OnWeaponShoot()
		{
			if (_self.TryGetAmmo(out ReactiveVariable<int> ammo) == false
			    || ammo.Value > 0)
			{
				_audioSource.PlayOneShot(_shootAudioClip);
				return;
			}

			var source = new GameObject();
			source.transform.SetPositionAndRotation(_soundSpawnPoint.position, _soundSpawnPoint.rotation);
			source.transform.SetParent(_soundSpawnPoint.root);
			var audioSource = source.AddComponent<AudioSource>();
			audioSource.PlayOneShot(_shootAudioClip, _audioSource.volume);

			Object.Destroy(source, _shootAudioClip.length);
		}

		public void Dispose(IEntity entity)
		{
			_attackEvent.Unsubscribe(OnWeaponShoot);
		}
	}
}