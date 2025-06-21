using System;
using Atomic.Entities;
using UnityEngine;

namespace Game
{
	[Serializable]
	public sealed class WorldUIInstaller : IEntityInstaller
	{
		[SerializeField]
		private GameObject _ui;
		
		public void Install(IEntity entity)
		{
			entity.AddEntityWorldUI(_ui);
		}
	}
}