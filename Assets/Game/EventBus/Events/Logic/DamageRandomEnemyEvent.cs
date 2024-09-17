using System;
using EventBus;
using UnityEngine;

namespace Entities
{
	[Serializable]
	public struct DamageRandomEnemyEvent : ICombatEvent
	{
		public Entity Source { get; set; }
		public int Damage;
		public GameObject Projectile;

		[field: SerializeField]
		public EventTriggerLink EventTriggerLink { get; set; }
		[field: SerializeField]

		public AudioClip[] AudioClips { get; set; }
	}
}