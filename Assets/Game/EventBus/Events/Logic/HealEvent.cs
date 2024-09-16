using Entities;

namespace EventBus
{
	public struct HealEvent : IEvent
	{
		public Entity Entity;
		public int Amount;

		public HealEvent(Entity entity, int amount)
		{
			Entity = entity;
			Amount = amount;
		}
	}
}