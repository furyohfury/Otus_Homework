using System;
using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Game
{
	[Serializable]
	public sealed class WeaponInstaller : IEntityInstaller
	{
		[SerializeField]
		private GameObject _weapon;

		public void Install(IEntity entity)
		{
			if (!entity.TryGetWeaponContainer(out Transform container))
			{
				Debug.LogWarning($"{entity.Name} doesn't have weapon container to install weapon");
				return;
			}
			
			var weaponGo = Object.Instantiate(_weapon, container);
			entity.AddWeapon(new ReactiveVariable<GameObject>(weaponGo));
		}
	}
}