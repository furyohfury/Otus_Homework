using System;
using Atomic.Entities;
using UnityEngine;

namespace Game
{
	[Serializable]
	public sealed class HealthInstaller : IEntityInstaller
	{
		[SerializeField]
		private int _health;
		
		public void Install(IEntity entity)
		{
			entity.AddHealth(_health);
		}
	}
}