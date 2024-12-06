using System;
using System.Linq;
using Atomic.Elements;
using Atomic.Entities;
using Atomic.Extensions;
using Game;
using UnityEngine;
using Object = UnityEngine.Object;

[Serializable]
public sealed class AbilityAspect : IEntityAspect
{
	[SerializeField]
	private int _numberOfUses;
	[SerializeField]
	private WeaponConfig _weaponConfig;
	[SerializeReference]
	private IEntityBehaviour[] _abilityBehaviours;

	public void Apply(IEntity entity)
	{
		InitAbility(entity);

		InitWeapon(entity);

		InitBehaviours(entity);
	}

	private void InitAbility(IEntity entity)
	{
		entity.AddAbilityUseNumber(new ReactiveVariable<int>(_numberOfUses));
		if (!entity.AddActiveAbilityAspect(new ReactiveVariable<IEntityAspect>(this)))
		{
			entity.GetActiveAbilityAspect().Value = this;
		}
	}

	private void InitWeapon(IEntity entity) // TODO mb raznesti
	{
		// if (!entity.TryGetWeapon(out ReactiveVariable<SceneEntity> weapon))
		// {
		// 	weapon = new ReactiveVariable<SceneEntity>();
		// 	entity.AddWeapon(weapon);
		// }
		//
		// var weaponGo = Object.Instantiate(_weaponConfig.WeaponPrefab, entity.GetWeaponContainer());
		// weapon.Value = weaponGo;
		// var firePoint = weaponGo
		//                 .GetComponentsInChildren<Transform>()
		//                 .SingleOrDefault(go => go.name == "FirePoint");
		//
		// if (firePoint == default)
		// {
		// 	Debug.LogError($"No fire point on {weapon.Value.name}. Creating default");
		// 	firePoint = weaponGo.transform;
		// }
		//
		// if (!entity.AddFirePoint(new ReactiveVariable<Transform>(firePoint)))
		// {
		// 	entity.GetFirePoint().Value = firePoint;
		// }
		
		if (!entity.AddProjectilePrefab(new ReactiveVariable<SceneEntity>(_weaponConfig.ProjectilePrefab)))
		{
			entity.GetProjectilePrefab().Value = _weaponConfig.ProjectilePrefab;
		}

		if (!entity.AddDamage(new ReactiveVariable<int>(_weaponConfig.Damage)))
		{
			entity.GetDamage().Value = _weaponConfig.Damage;
		}

		if (!entity.AddAttackDelay(new ReactiveVariable<float>(_weaponConfig.ShootDelay)))
		{
			entity.GetAttackDelay().Value = _weaponConfig.ShootDelay;
		}
		entity.GetAttackTimer().Duration = _weaponConfig.ShootDelay;

		if (!entity.AddAmmoSize(new ReactiveVariable<int>(_weaponConfig.AmmoSize)))
		{
			entity.GetAmmoSize().Value = _weaponConfig.AmmoSize;
		}

		if (!entity.AddAmmo(new ReactiveVariable<int>(_weaponConfig.AmmoSize)))
		{
			entity.GetAmmo().Value = _weaponConfig.AmmoSize;
		}

		if (_weaponConfig.SpreadAngle > 0)
		{
			entity.AddWeaponSpreadAngle(new ReactiveVariable<float>(_weaponConfig.SpreadAngle));
		}
	}

	private void InitBehaviours(IEntity entity)
	{
		foreach (var ability in _abilityBehaviours)
		{
			entity.AddBehaviour(ability);
		}

		if (!entity.HasBehaviour<AimWeaponBehaviour>())
		{
			entity.AddBehaviour<AimWeaponBehaviour>();
		}

		if (!entity.HasBehaviour<AbilityUseNumberBehaviour>())
		{
			entity.AddBehaviour<AbilityUseNumberBehaviour>();
		}

		if (!entity.HasBehaviour<SpendAmmoOnAttackBehaviour>())
		{
			entity.AddBehaviour<SpendAmmoOnAttackBehaviour>();
		}
	}

	public void Discard(IEntity entity)
	{
		foreach (var ability in _abilityBehaviours)
		{
			entity.DelBehaviour(ability);
		}

		entity.DelBehaviour<AimWeaponBehaviour>();
		entity.DelBehaviour<AbilityUseNumberBehaviour>();

		var weapon = entity.GetWeapon().Value;
		Object.Destroy(weapon);
		entity.DelWeapon();
		entity.DelProjectilePrefab();
		entity.DelFirePoint();
		entity.DelAmmo();
		entity.DelAmmoSize();
		entity.DelWeaponSpreadAngle();
		entity.DelAttackDelay();
		entity.DelDamage();
	}
}