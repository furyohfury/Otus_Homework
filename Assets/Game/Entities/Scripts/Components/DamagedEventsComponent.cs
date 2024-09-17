using System;
using System.Collections.Generic;
using EventBus;
using UnityEngine;

namespace Entities
{
	[Serializable]
	public sealed class DamagedEventsComponent : IComponent
	{
		[SerializeReference]
		public List<IEffect> Events = new();
	}
}