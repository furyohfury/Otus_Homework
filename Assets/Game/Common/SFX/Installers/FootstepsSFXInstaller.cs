using Atomic.Entities;
using UnityEngine;

namespace Game
{
	public sealed class FootstepsSFXInstaller : SceneEntityInstallerBase
	{
		[SerializeField] 
		private AudioClip[] _sounds;
		[SerializeField] 
		private AudioSource _audioSource;

		public override void Install(IEntity entity)
		{
			entity.AddFootstepsSounds(_sounds);
			entity.AddBehaviour<FootstepsSFXBehaviour>();

			if (entity.HasAudioSource() == false)
			{
				entity.AddAudioSource(_audioSource);
			}
		}
	}
}