using Entities;

namespace EventBus
{
	public struct DealDamageEvent : IEvent
	{
		public readonly Entity Source;
		public readonly Entity Target;
		public readonly int Damage;

		public DealDamageEvent(Entity source, Entity target, int damage)
		{
			Source = source;
			Target = target;
			Damage = damage;
		}
	}
}