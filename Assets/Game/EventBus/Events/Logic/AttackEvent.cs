using Entities;
using UI;

namespace Lessons.Lesson19_EventBus
{
	public class AttackEvent : IEvent
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