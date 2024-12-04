using System;
using Atomic.Entities;
using Atomic.Extensions;
using UnityEngine;

namespace Game
{
	[Serializable]
	public sealed class AbilityAspect : IEntityAspect
	{
		// [SerializeReference]
		// private IEntityInstaller[] _installers;
		// [SerializeReference]
		// private IEntityBehaviour[] _behaviours;
		
		public void Apply(IEntity entity)
		{
			
		}

		public void Discard(IEntity entity)
		{
			
		}
	}
}