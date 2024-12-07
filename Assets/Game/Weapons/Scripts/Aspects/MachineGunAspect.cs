﻿using System;
using Atomic.Elements;
using Atomic.Entities;
using Atomic.Extensions;
using UnityEngine;

namespace Game
{
	[Serializable]
	public sealed class MachineGunAspect : IEntityAspect
	{
		[SerializeField]
		private SceneEntity _machineGunPrefab;

		public void Apply(IEntity entity)
		{
			if (!entity.TryGetEquipWeaponRequest(out BaseEvent<SceneEntity> request))
			{
				Debug.LogError($"{entity.Name} has no equip weapon request");
				return;
			}

			request.Invoke(_machineGunPrefab);
		}

		public void Discard(IEntity entity)
		{
			if (!entity.TryGetUnequipWeaponRequest(out BaseEvent request))
			{
				Debug.LogError($"{entity.Name} has no equip weapon request");
				return;
			}

			request.Invoke();
		}
	}
}