using System;
using System.Collections.Generic;
using Lessons.Lesson19_EventBus;
using UnityEngine;

namespace Entities
{
	[Serializable]
	public sealed class AttackEffects : IComponent
	{
		[SerializeReference]
		public List<IEffect> Effects = new();
	}
}