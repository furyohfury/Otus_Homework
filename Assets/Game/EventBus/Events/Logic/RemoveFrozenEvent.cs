using Entities;
using UI;

namespace EventBus
{
	public struct RemoveFrozenEvent : IEvent
	{
		public Entity Target;
        public GameObject View;

		public RemoveFrozenEvent(Entity target)
		{
			Target = target;
            View = target.GetData<FrozenComponent>().View;
		}
	}        
}