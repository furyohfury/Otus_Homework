using System;
using EventBus;

namespace Entities
{
	[Serializable]
	public struct FireProjectileVisualEvent : ICombatEvent
	{
		public Entity Source { get; set; }
		public Entity Target;

		public FireProjectileVisualEvent(Entity source, Entity target)
		{
			Source = source;
			Target = target;
		}
	}
}