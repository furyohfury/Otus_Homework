using System;
using System.Linq;
using Atomic.Elements;
using Atomic.Entities;
using Atomic.Extensions;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Game
{
	[Serializable]
	public class JumpAbilityAspect : IEntityAspect
	{
		// [SerializeField]
		// private GameObject _projectilePrefab;
		// [SerializeField]
		// private GameObject _weaponPrefab;
		[SerializeField]
		private WeaponConfig _weaponConfig;

		public void Apply(IEntity entity)
		{
			if (entity.TryGetWeapon(out ReactiveVariable<GameObject> weapon))
			{
				entity.GetProjectilePrefab().Value = _weaponConfig.ProjectilePrefab;
				var weaponGo = Object.Instantiate(_weaponConfig.WeaponPrefab, entity.GetWeaponContainer());
				weapon.Value = weaponGo;
				var firePoint = weaponGo
				                .GetComponentsInChildren<Transform>()
				                .SingleOrDefault(go => go.name == "FirePoint");

				if (firePoint != null)
				{
					entity.GetFirePoint().Value = firePoint;
				}
				else
				{
					Debug.LogError("Nor firepoint on weapon");
				}
			}

			entity.AddBehaviour<PistolShootBehaviour>();
			entity.AddBehaviour<JumpAbilityBehaviour>();
		}

		public void Discard(IEntity entity)
		{
			entity.DelBehaviour<JumpAbilityBehaviour>();
		}
	}
}