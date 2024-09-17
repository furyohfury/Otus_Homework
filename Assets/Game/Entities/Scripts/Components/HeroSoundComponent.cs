using UnityEngine;

namespace Entities
{
	public sealed class HeroSoundComponent : IComponent
	{
		public AudioClip[] StartTurnClips;
		public AudioClip[] LowHealthClips;
		public AudioClip[] AbilityClips;
		public AudioClip[] DeathClips;
	}
}