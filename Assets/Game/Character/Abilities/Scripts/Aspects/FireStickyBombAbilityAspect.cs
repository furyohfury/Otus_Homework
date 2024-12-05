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
	public sealed class FireStickyBombAbilityAspect : IEntityAspect
	{
		[SerializeField]
		private int _numberOfUses;
		[SerializeField]
		private WeaponConfig _weaponConfig;

		public void Apply(IEntity entity)
		{
			InitAbility(entity);

			InitWeapon(entity);

			InitBehaviours(entity);
		}

		private void InitAbility(IEntity entity)
		{
			entity.AddAbilityUseNumber(new ReactiveVariable<int>(_numberOfUses));
			entity.AddActiveAbilityAspect(this);
		}

		private void InitWeapon(IEntity entity)
		{
			
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
					Debug.LogError($"No fire point on {weapon.Value.name}");
				}
			}
		}

		private void InitBehaviours(IEntity entity)
		{
			entity.AddBehaviour<MachineGunShootBehaviour>();
			entity.AddBehaviour<FireStickyBombAbilityBehaviour>();

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
			entity.DelBehaviour<FireStickyBombAbilityBehaviour>();
			entity.DelBehaviour<MachineGunShootBehaviour>();
			entity.DelBehaviour<AimWeaponBehaviour>();

			var weapon = entity.GetWeapon().Value;
			Object.Destroy(weapon);
			entity.DelWeapon();
			entity.DelFirePoint();
		}
	}
}