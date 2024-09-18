using Entities;

namespace EventBus
{
	public struct DealDamageEvent : IEvent
	{
		public Entity Source;
		public Entity Target;
		public int Damage;

		public DealDamageEvent(Entity source, Entity target, int damage)
		{
			Source = source;
			Target = target;
			Damage = damage;
		}
	}
}