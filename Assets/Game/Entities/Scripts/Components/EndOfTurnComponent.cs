using System;
using System.Collections.Generic;
using EventBus;
using UnityEngine;

namespace Entities
{
	[Serializable]
	public sealed class EndOfTurnComponent : IComponent
	{
		[SerializeReference]
		public List<ICombatEvent> Events = new();
	}
}