using System;
using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.Entities
{
	[Serializable]
	public sealed class BulletInstaller : IEntityInstaller
	{
		[SerializeField]
		private Transform _visualTransform;
		[SerializeField]
		private TriggerReceiver _triggerReceiver;
		[SerializeField]
		private Collider2D _collider2D;
		[SerializeField]
		private Rigidbody2D _rigidbody2D;
		[SerializeField]
		private int _damage;
		[SerializeField]
		private float _moveSpeed;

		public void Install(IEntity entity)
		{
			entity.AddMoveDirection(new ReactiveVariable<Vector2>(_visualTransform.right));
			entity.AddVisualTransform(_visualTransform);
			entity.AddDamage(_damage);
			entity.AddTriggerReceiver(_triggerReceiver);
			entity.AddTriggerEnterEvent(new BaseEvent<Collider2D>());
			entity.AddTriggerExitEvent(new BaseEvent<Collider2D>());
			entity.AddCollider2D(_collider2D);
			entity.AddRigidbody(_rigidbody2D);
			entity.AddMoveSpeed(_moveSpeed);
			entity.AddCanMove(new AndExpression());
			entity.AddDeathEvent(new BaseEvent());
			
			entity.AddBehaviour(new BulletCollisionBehaviour());
			entity.AddBehaviour(new MovementByTransformBehaviour());
			entity.AddBehaviour(new DestroyGameObjectOnDeathBehaviour());
		}
	}
}