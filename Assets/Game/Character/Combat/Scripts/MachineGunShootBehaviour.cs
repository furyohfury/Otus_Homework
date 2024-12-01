using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game
{
	public sealed class MachineGunShootBehaviour : IEntityInit, IEntityDispose
	{
		private BaseEvent _attackEvent;
		private GameObject _machineGunPrefab;
		private IValue<Transform> _firePoint;
		private IValue<float> _machineGunSpreadAngle;

		public void Init(IEntity entity)
		{
			_machineGunPrefab = entity.GetMachineGunBulletPrefab();
			_firePoint = entity.GetFirePoint();
			_machineGunSpreadAngle = entity.GetMachineGunSpreadAngle();

			_attackEvent = entity.GetAttackEvent();
			_attackEvent.Subscribe(OnAttackEvent);
		}

		private void OnAttackEvent()
		{
			var spreadAngle = Random.Range(-_machineGunSpreadAngle.Value, _machineGunSpreadAngle.Value);
			Quaternion rotation = _firePoint.Value.rotation * Quaternion.Euler(new Vector3(0, 0, spreadAngle));
			GameObject.Instantiate(_machineGunPrefab, _firePoint.Value.position, rotation);
		}

		public void Dispose(IEntity entity)
		{
			_attackEvent.Unsubscribe(OnAttackEvent);
		}
	}
}