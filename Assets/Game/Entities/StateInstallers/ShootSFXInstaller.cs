using System;
using Atomic.Entities;
using UnityEngine;

namespace Game
{
	[Serializable]
	public sealed class ShootSFXInstaller : IEntityInstaller
	{
		[SerializeField]
		private AudioClip[] _clips;
		
		public void Install(IEntity entity)
		{
			entity.AddShootSFX(_clips);
		}
	}
}