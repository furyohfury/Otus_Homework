using UnityEngine;

namespace Entities
{
	public sealed class HeroStartTurnSoundComponent : IComponent
	{
		public AudioClip[] AudioClips;

		public HeroStartTurnSoundComponent(AudioClip[] audioClips)
		{
			AudioClips = audioClips;
		}
	}
}