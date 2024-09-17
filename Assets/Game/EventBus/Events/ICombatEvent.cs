using Entities;

namespace EventBus
{
    public interface ICombatEvent : IEvent
	{
		public Entity Source { get; set; }
		public EventTriggerLink EventTriggerLink { get; }
	}	
}