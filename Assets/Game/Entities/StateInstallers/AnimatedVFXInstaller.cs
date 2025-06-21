using System;
using Atomic.Entities;
using UnityEngine;

namespace Game
{
	[Serializable]
	public sealed class AnimatedVFXInstaller : IEntityInstaller
	{
		[SerializeField]
		private AnimatedVFX _vfx;
		
		public void Install(IEntity entity)
		{
			entity.AddAttackVFX(_vfx);
		}
	}
}