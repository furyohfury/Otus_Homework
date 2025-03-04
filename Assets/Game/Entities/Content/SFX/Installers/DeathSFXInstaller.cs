using Atomic.Entities;
using UnityEngine;

namespace Game
{
	public sealed class DeathSFXInstaller : SceneEntityInstallerBase
	{
		[SerializeField]
		private AudioClip[] _deathSounds;
		[SerializeField]
		private AudioSource _audioSource;

		public override void Install(IEntity entity)
		{
			entity.AddDeathSounds(_deathSounds);
			entity.AddBehaviour<DeathSFXBehaviour>();

			if (entity.HasAudioSource() == false)
			{
				entity.AddAudioSource(_audioSource);
			}
		}
	}
}