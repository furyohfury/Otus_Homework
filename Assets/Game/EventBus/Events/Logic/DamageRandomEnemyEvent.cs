using System;
using EventBus;

namespace Entities
{
	[Serializable]
	public struct DamageRandomEnemyEvent : ICombatEvent
	{
		public Entity Source { get; set; }
		public int Damage;
		public GameObject Projectile;
	}
}