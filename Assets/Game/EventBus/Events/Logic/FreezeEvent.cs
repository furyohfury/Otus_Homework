using Entities;

namespace EventBus
{
	public struct FreezeEvent : IEvent
	{
		public readonly Entity Target;

		public FreezeEvent(Entity target)
		{
			Target = target;
		}
	}
}