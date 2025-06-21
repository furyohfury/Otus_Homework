using System;
using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game
{
	[Serializable]
	public sealed class SpreadAngleWeaponInstaller : IEntityInstaller
	{
		[SerializeField]
		private float _angle;
		
		public void Install(IEntity entity)
		{
			entity.AddWeaponSpreadAngle(new ReactiveVariable<float>(_angle));
		}
	}
}