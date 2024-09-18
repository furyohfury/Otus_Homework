using Entities;

namespace EventBus
{
	public struct AttackEvent : IEvent
	{
		public Entity Source;
		public Entity Target;

		public AttackEvent(Entity source, Entity target)
		{
			Source = source;
			Target = target;
		}
	}
}