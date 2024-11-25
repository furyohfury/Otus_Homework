using System;
using Atomic.Entities;
using Atomic.Extensions;
using UnityEngine;

namespace Game
{
	[Serializable]
	public sealed class LifeInstaller : IEntityInstaller
	{
		[SerializeField]
		private LifeAspect _lifeAspect;
		
		public void Install(IEntity entity)
		{
			entity.ApplyAspect(_lifeAspect);	
		}
	}
}