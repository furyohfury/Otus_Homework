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
	public sealed class JumpAbilityAspect : IEntityAspect
	{
		[SerializeField]
		private int _numberOfUses;
		[SerializeField]
		private WeaponConfig _weaponConfig;

		public void Apply(IEntity entity)
		{
			entity.AddAbilityUseNumber(new ReactiveVariable<int>(_numberOfUses));
			entity.AddActiveAspect(this);

			if (entity.HasAttackDelay())
			{
				entity.GetAttackDelay().Value = _weaponConfig.ShootDelay;
			}
			else
			{
				entity.AddAttackDelay(new ReactiveVariable<float>(_weaponConfig.ShootDelay));
			}
			
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

			if (!entity.HasBehaviour<AimWeaponBehaviour>())
			{
				entity.AddBehaviour<AimWeaponBehaviour>();
			}
			
			if (!entity.HasBehaviour<AbilityUseNumberBehaviour>())
			{
				entity.AddBehaviour<AbilityUseNumberBehaviour>();
			}
		}

		public void Discard(IEntity entity)
		{
			entity.DelBehaviour<JumpAbilityBehaviour>();
			entity.DelBehaviour<PistolShootBehaviour>();
			entity.DelBehaviour<AimWeaponBehaviour>();

			var weapon = entity.GetWeapon().Value;
			Object.Destroy(weapon);
			entity.DelWeapon();
			entity.DelFirePoint();
		}
	}
}