using Entities;

namespace EventBus
{
	public struct FreezeEvent : IEvent
	{
		public Entity Target;

		public FreezeEvent(Entity target)
		{
			Target = target;
		}
	}
}