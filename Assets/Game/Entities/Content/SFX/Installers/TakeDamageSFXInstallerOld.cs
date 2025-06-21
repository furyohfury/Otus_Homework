using Atomic.Entities;
using UnityEngine;

namespace Game
{
	public sealed class TakeDamageSFXInstallerOld : SceneEntityInstallerBase
	{
		[SerializeField]
		private AudioClip[] _takeDamageSounds;
		[SerializeField]
		private AudioSource _audioSource;

		public override void Install(IEntity entity)
		{
			entity.AddTakeDamageSounds(_takeDamageSounds);
			entity.AddBehaviour<TakeDamageSFXBehaviour>();

			if (entity.HasAudioSource() == false)
			{
				entity.AddAudioSource(_audioSource);
			}
		}
	}
}