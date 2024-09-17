using System;
using Entities;
using UnityEngine;

namespace EventBus
{
	[Serializable]
	public struct DamageAllEffect : IEffect
	{
		public Entity Source { get; set; }
		[field: SerializeField]
		public EventTriggerLink EventTriggerLink { get; set; }
		[field: SerializeField]
		public AudioClip[] AudioClips { get; set; }
		public int Damage;
		public ParticleSystem ParticleSystem;
	}
}