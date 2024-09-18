using Entities;

namespace EventBus
{
	public struct VampiricEvent : IEvent
	{
		public readonly Entity Entity;
		public readonly int Damage;
		public readonly float Probability;

		public VampiricEvent(Entity entity, int damage, float probability)
		{
			Entity = entity;
			Damage = damage;
			Probability = probability;
		}
	}
}