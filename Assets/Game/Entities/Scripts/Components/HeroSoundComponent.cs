using System;
using UnityEngine;

namespace Entities
{
	[Serializable]
	public sealed class HeroSoundComponent : IComponent
	{
		public AudioClip[] StartTurnClips;
		public AudioClip[] LowHealthClips;
		public AudioClip[] AbilityClips;
		public AudioClip[] DeathClips;
	}
}