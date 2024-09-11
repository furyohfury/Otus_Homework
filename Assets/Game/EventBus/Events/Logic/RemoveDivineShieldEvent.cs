using Entities;
using UnityEngine;

namespace EventBus
{
	public class RemoveDivineShieldEvent : IEvent
	{
		public readonly Entity Entity;
		public readonly GameObject ShieldView;

		public RemoveDivineShieldEvent(Entity entity)
		{
			Entity = entity;
			entity.TryGetData(out DivineShieldComponent divineShieldComponent);
			ShieldView = divineShieldComponent.DivineShieldView;
		}
	}
}