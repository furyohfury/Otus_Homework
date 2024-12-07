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
		private float _moveSpeed;
		[SerializeField]
		private Rigidbody2D _rigidbody;
		[SerializeField]
		private float _lifeDuration;
		

		public void Install(IEntity entity)
		{
			entity.AddMoveDirection(new ReactiveVariable<Vector2>(_visualTransform.right));
			entity.AddVisualTransform(_visualTransform);
			entity.AddDamage(new ReactiveVariable<int>());
			entity.AddTriggerReceiver(_triggerReceiver);
			entity.AddCollider2D(_collider2D);
			entity.AddMoveSpeed(new ReactiveVariable<float>(_moveSpeed));
			entity.AddDeathEvent(new BaseEvent());
			entity.AddRigidbody(_rigidbody);

			var lifetimeTimer = new Timer(_lifeDuration);
			lifetimeTimer.Start();
			entity.WhenUpdate(lifetimeTimer.Tick);
			entity.AddLifetimeTimer(lifetimeTimer);
			
			InstallBehaviours(entity);
		}

		private static void InstallBehaviours(IEntity entity)
		{
			entity.AddBehaviour(new BulletCollisionBehaviour());
			entity.AddBehaviour(new MovementByKinematicRbBehaviour());
			entity.AddBehaviour<LifetimeBehaviour>();
		}
	}
}