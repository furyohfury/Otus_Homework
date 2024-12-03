using System;
using System.Collections.Generic;
using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game
{
	public sealed class PistolShootBehaviour : IEntityInit, IEntityDispose
	{
		private BaseEvent _attackEvent;
		private IValue<SceneEntity> _pistolBulletPrefab;
		private IValue<Transform> _firePoint;
		private IValue<GameObject> _weapon;
		private Pool<SceneEntity> _pool;
		
		private readonly Dictionary<SceneEntity, Action> _deathEventSubscriptions = new();

		public void Init(IEntity entity)
		{
			_pistolBulletPrefab = entity.GetProjectilePrefab();
			_firePoint = entity.GetFirePoint();
			_attackEvent = entity.GetAttackEvent();
			_weapon = entity.GetWeapon();
			_attackEvent.Subscribe(OnAttackEvent);

			_pool = new Pool<SceneEntity>(_weapon.Value.transform, _pistolBulletPrefab.Value, true);
		}

		private void OnAttackEvent()
		{
			// TODO how to get world transform?
			// TODO shoots with negative scale cuz of weapon rotation
			var bullet = _pool.Get(_firePoint.Value.position, _firePoint.Value.rotation);
			bullet.GetMoveDirection().Value = bullet.GetVisualTransform().right;
			if (bullet.TryGetDeathEvent(out BaseEvent deathEvent))
			{
				var subscription =  deathEvent.Subscribe(() => ReturnToPool(bullet));
				_deathEventSubscriptions[bullet] = subscription;
			}
			else
			{
				Debug.LogError("Bullet has no death event");
			}			
		}

		private void ReturnToPool(SceneEntity bullet)
		{
			if (_deathEventSubscriptions.TryGetValue(bullet, out var subscription))
			{
				bullet.GetDeathEvent().Unsubscribe(subscription);
				_deathEventSubscriptions.Remove(bullet);
			}
			_pool.Return(bullet);
		}

		public void Dispose(IEntity entity)
		{
			_attackEvent.Unsubscribe(OnAttackEvent);

			foreach (var bullet in _pool.ActiveItems)
			{
				if (_deathEventSubscriptions.TryGetValue(bullet, out var subscription))
				{
					bullet.GetDeathEvent().Unsubscribe(subscription);
					_deathEventSubscriptions.Remove(bullet);
					bullet.AddBehaviour<DestroyGameObjectOnDeathBehaviour>();
				}
			}

			_pool.Dispose();
		}
	}
}