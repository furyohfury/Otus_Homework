using System;
using Entities;

namespace EventBus
{
	[Serializable]
	public struct DamageAllEvent : ICombatEvent
	{
		public Entity Source { get; set; }
		public int Damage;
	}
}