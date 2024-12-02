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

		public void Init(IEntity entity)
		{
			_pistolBulletPrefab = entity.GetProjectilePrefab();
			_firePoint = entity.GetFirePoint();
			_attackEvent = entity.GetAttackEvent();
			_weapon = entity.GetWeapon();
			_attackEvent.Subscribe(OnAttackEvent);

			_pool = new(_weapon, _pistolBulletPrefab.Value, true);
		}

		private void OnAttackEvent()
		{
			// TODO how to get world transform?
			var bullet = _pool.Get(_weapon.transform, _firePoint.Value.position, _firePoint.Value.rotation);
			if (bullet.TryGetDeathEvent(out BaseEvent deathEvent))
			{
				deathEvent.Subscribe(ReturnToPool);
				// TODO make deathevent BaseEvent<SceneEntity>
			}
			else
			{
				Debug.LogError("Bullet has no death event");
			}			
		}

		private void ReturnToPool(SceneEntity entity)
		{
			_pool.Return(entity);
		}

		public void Dispose(IEntity entity)
		{
			_attackEvent.Unsubscribe(OnAttackEvent);
			foreach (var bullet in _pool.ActiveItems)
			{
				if (bullet.TryGetDeathEvent(out BaseEvent deathEvent))
				{
					deathEvent.Unsubscribe(ReturnToPool);
					bullet.AddBehaviour<DestroyGameObjectOnDeathBehaviour>();
				}
			}

			_pool.Dispose();
		}
	}
}