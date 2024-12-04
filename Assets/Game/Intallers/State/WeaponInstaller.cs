using System;
using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game
{
	[Serializable]
	public sealed class WeaponInstaller : IEntityInstaller
	{
		[SerializeField]
		private GameObject _weapon;
		
		public void Install(IEntity entity)
		{
			entity.AddWeapon(new ReactiveVariable<GameObject>(_weapon));
		}
	}
}