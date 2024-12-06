using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game
{
	public sealed class EquipWeaponBehaviour : IEntityInit, IEntityDispose
	{
		private IEntity _entity;
		private Transform _weaponContainer;
		private BaseEvent<SceneEntity> _equipWeaponRequest;
		private BaseEvent<SceneEntity> _unequipWeaponRequest;

		public void Init(IEntity entity)
		{
			_entity = entity;
			_weaponContainer = entity.GetWeaponContainer();
			
			_equipWeaponRequest = entity.GetEquipWeaponRequest();
			_equipWeaponRequest.Subscribe(OnWeaponEquip);
			
			_unequipWeaponRequest = entity.GetUnequipWeaponRequest();
			_unequipWeaponRequest.Subscribe(OnWeaponUnequip);
		}

		private void OnWeaponEquip(SceneEntity weapon)
		{
			var weaponTransform = weapon.GetVisualTransform();
			weaponTransform.SetParent(_weaponContainer);
			_entity.AddWeapon(weapon);
		}

		private void OnWeaponUnequip(SceneEntity weapon)
		{
			Object.Destroy(weapon.gameObject);
			_entity.DelWeapon();
		}

		public void Dispose(IEntity entity)
		{
			_equipWeaponRequest.Unsubscribe(OnWeaponEquip);
			_unequipWeaponRequest.Unsubscribe(OnWeaponUnequip);
		}
	}
}