using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game
{
	public sealed class PistolShootBehaviour : IEntityInit, IEntityDispose
	{
		private BaseEvent _attackEvent;
		private IValue<GameObject> _pistolBulletPrefab;
		private IValue<Transform> _firePoint;

		public void Init(IEntity entity)
		{
			_pistolBulletPrefab = entity.GetProjectilePrefab();
			_firePoint = entity.GetFirePoint();
			_attackEvent = entity.GetAttackEvent();
			_attackEvent.Subscribe(OnAttackEvent);
		}

		private void OnAttackEvent()
		{
			// TODO use pool with world?
			
			//can make pool HERE lol
			GameObject.Instantiate(_pistolBulletPrefab.Value, _firePoint.Value.position, _firePoint.Value.rotation);
		}

		public void Dispose(IEntity entity)
		{
			_attackEvent.Unsubscribe(OnAttackEvent);
		}
	}
}