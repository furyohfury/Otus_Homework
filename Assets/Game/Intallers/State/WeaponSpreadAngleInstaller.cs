using System;
using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game
{
	[Serializable]
	public sealed class WeaponSpreadAngleInstaller : IEntityInstaller
	{
		[SerializeField]
		private float _spreadAngle;
		
		public void Install(IEntity entity)
		{
			entity.AddWeaponSpreadAngle(new ReactiveVariable<float>(_spreadAngle));
		}
	}
}