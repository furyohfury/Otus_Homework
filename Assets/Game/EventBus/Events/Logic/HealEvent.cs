using Entities;

namespace EventBus
{
	public struct HealEvent : IEvent
	{
		public readonly Entity Entity;
		public readonly int Amount;

		public HealEvent(Entity entity, int amount)
		{
			Entity = entity;
			Amount = amount;
		}
	}
}