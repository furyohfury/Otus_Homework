using System;
using Entities;
using UnityEngine;

namespace EventBus
{
	[Serializable]
	public struct DamageAllEvent : ICombatEvent
	{
		public Entity Source { get; set; }
		public int Damage;
		[field: SerializeField]
		public EventTriggerLink EventTriggerLink { get; set; }
		[field: SerializeField]
		public AudioClip[] AudioClips { get; set; }
	}
}