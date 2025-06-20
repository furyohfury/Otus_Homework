using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Game
{
	public sealed class SpreadAngleWeaponBehaviour : IEntityInit, IEntityDispose
	{
		private BaseEvent _attackEvent;
		private IValue<Transform> _firePoint;
		private IValue<float> _weaponSpreadAngle;
		private IValue<int> _damage;
		private IValue<SceneEntity> _bulletPrefab;
		private Transform _container;

		public void Init(IEntity entity)
		{
			_damage = entity.GetDamage();
			_weaponSpreadAngle = entity.GetWeaponSpreadAngle();
			_bulletPrefab = entity.GetProjectilePrefab();
			_firePoint = entity.GetFirePoint();
			_attackEvent = entity.GetAttackEvent();
			_attackEvent.Subscribe(OnAttackEvent);
			_container = entity.GetVisualTransform().root;
		}

		private void OnAttackEvent()
		{
			var spreadAngle = _weaponSpreadAngle.Value;
			var randomAngle = Random.Range(-spreadAngle, spreadAngle);
			var rotation = _firePoint.Value.rotation * Quaternion.Euler(new Vector3(0, 0, randomAngle));
			var bullet = SceneEntity.Instantiate(_bulletPrefab.Value, _firePoint.Value.position, rotation, _container);

			bullet.GetDamage().Value = _damage.Value;
			bullet.GetMoveDirection().Value = bullet.GetVisualTransform().right;
		}

		public void Dispose(IEntity entity)
		{
			_attackEvent.Unsubscribe(OnAttackEvent);
		}
	}
}