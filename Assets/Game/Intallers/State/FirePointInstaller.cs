using System;
using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game
{
	[Serializable]
	public sealed class FirePointInstaller : IEntityInstaller
	{
		[SerializeField]
		private Transform _firePoint;
		
		public void Install(IEntity entity)
		{
			entity.AddFirePoint(new ReactiveVariable<Transform>(_firePoint));
		}
	}
}