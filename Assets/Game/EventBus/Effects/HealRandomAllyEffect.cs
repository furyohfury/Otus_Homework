using System;
using Entities;
using UnityEngine;

namespace EventBus
{
	[Serializable]
	public struct HealRandomAllyEffect : IEffect
	{
		public Entity Source { get; set; }
		public int Amount;

		[field: SerializeField]
		public EventTriggerLink EventTriggerLink { get; set; }

		[field: SerializeField]
		public AudioClip[] AudioClips { get; set; }
	}
}