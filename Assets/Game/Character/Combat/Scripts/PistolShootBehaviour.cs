using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game
{
	public sealed class PistolShootBehaviour : IEntityInit, IEntityDispose
	{
		private BaseEvent _attackEvent;
		private GameObject _pistolBulletPrefab;
		private Transform _firePoint;

		public void Init(IEntity entity)
		{
			_pistolBulletPrefab = entity.GetPistolBulletPrefab();
			_firePoint = entity.GetFirePoint();
			_attackEvent = entity.GetAttackEvent();
			_attackEvent.Subscribe(OnAttackEvent);
		}

		private void OnAttackEvent()
		{
			// TODO use pool with world?
			
			//can make pool HERE lol
			GameObject.Instantiate(_pistolBulletPrefab, _firePoint.position, _firePoint.rotation);
		}

		public void Dispose(IEntity entity)
		{
			_attackEvent.Unsubscribe(OnAttackEvent);
		}
	}
}