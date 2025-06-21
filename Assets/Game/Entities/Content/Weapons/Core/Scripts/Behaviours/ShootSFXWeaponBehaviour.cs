using Atomic.Elements;
using Atomic.Entities;
using DG.Tweening;
using UnityEngine;

namespace Game
{
	public sealed class ShootSFXWeaponBehaviour : IEntityInit, IEntityDispose
	{
		private IEntity _self;
		private BaseEvent _attackEvent;
		private AudioSource _audioSource;
		private AudioClip[] _shootSFXs;
		private Transform _soundSpawnPoint;

		public void Init(IEntity entity)
		{
			_self = entity;
			_soundSpawnPoint = entity.TryGetFirePoint(out var firePoint)
				? firePoint.Value
				: entity.GetVisualTransform();

			_audioSource = entity.GetAudioSource();
			_shootSFXs = entity.GetShootSFX();

			_attackEvent = entity.GetAttackEvent();
			_attackEvent.Subscribe(OnWeaponShoot);
		}

		private void OnWeaponShoot()
		{
			var clip = _shootSFXs[Random.Range(0, _shootSFXs.Length)];
			if (_self.TryGetAmmo(out ReactiveVariable<int> ammo) == false
			    || ammo.Value > 0)
			{
				_audioSource.PlayOneShot(clip);
				return;
			}

			var source = new GameObject();
			source.transform.SetParent(_soundSpawnPoint.root);
			var audioSource = source.AddComponent<AudioSource>();
			audioSource.PlayOneShot(clip, _audioSource.volume);

			DOVirtual.DelayedCall(clip.length, () => Object.Destroy(source));
		}

		public void Dispose(IEntity entity)
		{
			_attackEvent.Unsubscribe(OnWeaponShoot);
		}
	}
}