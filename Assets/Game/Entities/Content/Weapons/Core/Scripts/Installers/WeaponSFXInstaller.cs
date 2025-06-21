using Atomic.Entities;
using UnityEngine;

namespace Game
{
	public sealed class WeaponSFXInstaller : SceneEntityInstallerBase
	{
		[SerializeField]
		private AudioSource _audioSource;
		[SerializeField]
		private AudioClip _shootSFX;

		public override void Install(IEntity entity)
		{
			entity.AddAudioSource(_audioSource);
			// entity.AddShootAudioClip(_shootSFX);

			entity.AddBehaviour<ShootSFXWeaponBehaviour>();
		}
	}
}