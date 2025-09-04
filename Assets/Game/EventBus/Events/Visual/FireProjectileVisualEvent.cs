using System;
using EventBus;
using UnityEngine;

namespace Entities
{
	[Serializable]
	public struct FireProjectileVisualEvent : IEvent
	{
		public Entity Source { get; set; }
		public Entity Target;
		public GameObject Projectile;

		public FireProjectileVisualEvent(Entity source, Entity target, GameObject projectile)
		{
			Source = source;
			Target = target;
			Projectile = projectile;
		}
	}
}