using Entities;
using UnityEngine;

namespace EventBus
{
	public struct RemoveFrozenEvent : IEvent
	{
		public readonly Entity Target;
		public readonly GameObject View;

		public RemoveFrozenEvent(Entity target)
		{
			Target = target;
			View = target.GetData<FrozenComponent>().View;
		}
	}
}