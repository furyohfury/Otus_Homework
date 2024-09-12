using Entities;
using UnityEngine;

namespace EventBus
{
	public struct RemoveDivineShieldEvent : IEvent
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