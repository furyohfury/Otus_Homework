using Entities;
using UI;

namespace Lessons.Lesson19_EventBus
{
	public class RemoveDivineShieldEvent : IEvent
	{
		public Entity Entity;
        public GameObject ShieldView;

		public RemoveDivineShieldEvent(Entity entity)
		{
            Entity = entity;
            entity.TryGetData(out DivineShieldComponent divineShieldComponent);
            ShieldView = divineShieldComponent.DivineShieldView;
		}
	}
}