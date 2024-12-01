using System;
using System.Linq;
using Atomic.Elements;
using Atomic.Entities;
using Atomic.Extensions;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game
{
	[Serializable]
	public class JumpAbilityAspect : IEntityAspect
	{
		[SerializeField]
		private GameObject _weaponPrefab;
		[SerializeField]
		private Transform _firePoint;
		
		public void Apply(IEntity entity)
		{
			if (entity.TryGetWeapon(out ReactiveVariable<GameObject> weapon))
			{
				var weaponGo = GameObject.Instantiate(_weaponPrefab, entity.GetWeaponContainer());
				weapon.Value = weaponGo;
				entity.GetFirePoint().Value = _firePoint;
			}
			
			entity.AddBehaviour<PistolShootBehaviour>();
			entity.AddBehaviour<JumpAbilityBehaviour>();
		}

		public void Discard(IEntity entity)
		{
			entity.DelBehaviour<JumpAbilityBehaviour>();
		}

		[Button]
		private void GetFirePoint()
		{
			if (_weaponPrefab == null)
			{
				return;
			}

			var firePoint = _weaponPrefab
			                .GetComponentsInChildren<Transform>()
			                .SingleOrDefault(go => go.name == "FirePoint");

			if (firePoint != null)
			{
				_firePoint = firePoint;
			}
		}
	}
}