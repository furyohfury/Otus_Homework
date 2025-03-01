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
		private BaseEvent _unequipWeaponRequest;

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
			var weaponGo = SceneEntity.Instantiate(weapon, _weaponContainer.position, _weaponContainer.rotation, _weaponContainer);
			if (_entity.TryGetSpawnWorldEvent(out IEvent<IEntity> spawnWorldEvent))
			{
				spawnWorldEvent.Invoke(weaponGo);
			}
			_entity.AddWeapon(weaponGo);
		}

		private void OnWeaponUnequip()
		{
			if (_entity.TryGetWeapon(out ReactiveVariable<SceneEntity> weapon))
			{
				if (_entity.TryGetDestroyWorldEvent(out IEvent<IEntity> destroyWorldEvent))
				{
					destroyWorldEvent.Invoke(weapon.Value);
				}
				Object.Destroy(weapon.Value.gameObject);
				_entity.DelWeapon();
			}
		}

		public void Dispose(IEntity entity)
		{
			_equipWeaponRequest?.Unsubscribe(OnWeaponEquip);
			_unequipWeaponRequest?.Unsubscribe(OnWeaponUnequip);
		}
	}
}