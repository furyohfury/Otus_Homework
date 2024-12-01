using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game
{
	public sealed class RifleShootBehaviour : IEntityInit, IEntityDispose
	{
		private BaseEvent _attackEvent;
		private GameObject _rifleBulletPrefab;
		private IValue<Transform> _firePoint;

		public void Init(IEntity entity)
		{
			_rifleBulletPrefab = entity.GetRifleBulletPrefab();
			_firePoint = entity.GetFirePoint();
			_attackEvent = entity.GetAttackEvent();
			_attackEvent.Subscribe(OnAttackEvent);
		}

		private void OnAttackEvent()
		{
			GameObject.Instantiate(_rifleBulletPrefab, _firePoint.Value.position, _firePoint.Value.rotation);
		}

		public void Dispose(IEntity entity)
		{
			_attackEvent.Unsubscribe(OnAttackEvent);
		}
	}
}