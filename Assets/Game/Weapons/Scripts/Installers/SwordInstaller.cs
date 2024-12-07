using System;
using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.Entities
{
	[Serializable]
	public sealed class SwordInstaller : IEntityInstaller
	{
		[SerializeField]
		private Transform _visualTransform;
		[SerializeField]
		private TriggerReceiver _triggerReceiver;
		[SerializeField]
		private Collider2D _collider2D;
		[SerializeField]
		private Vector3 _attackRotationAngle;
		[SerializeField]
		private float _slashSpeed;
		[SerializeField]
		private float _restoreSlashSpeed;
		[SerializeField]
		private int _damage;

		public void Install(IEntity entity)
		{
			entity.AddAttackRotationAngle(_attackRotationAngle);
			entity.AddVisualTransform(_visualTransform);
			entity.AddDamage(_damage);
			entity.AddTriggerReceiver(_triggerReceiver);
			entity.AddTriggerEnterEvent(new BaseEvent<Collider2D>());
			entity.AddTriggerExitEvent(new BaseEvent<Collider2D>());
			entity.AddCollider2D(_collider2D);
			entity.AddSlashSpeed(_slashSpeed);
			entity.AddRestoreSlashSpeed(_restoreSlashSpeed);
			
			entity.AddBehaviour(new SwordCollisionBehaviour());
		}
	}
}