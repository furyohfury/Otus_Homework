using System;
using Atomic.Elements;
using Atomic.Entities;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Entities
{
	[Serializable]
	public sealed class BulletInstaller : SceneEntityInstallerBase
	{
		[SerializeField] [Required]
		private string _id;
		[SerializeField] [Header("Components")]
		private Transform _visualTransform;
		[SerializeField]
		private Collider2D _collider2D;
		[SerializeField]
		private Rigidbody2D _rigidbody;
		[SerializeField]
		private TriggerReceiver _triggerReceiver;
		[SerializeField] [Header("Parameters")]
		private float _moveSpeed = 100f;
		[SerializeField]
		private float _lifeDuration = 5f;

		public override void Install(IEntity entity)
		{
			entity.AddId(_id);
			entity.AddBulletTag();
			InstallComponents(entity);
			InstallParameters(entity);
			InstallEvents(entity);

			InstallBehaviours(entity);
		}

		private void InstallEvents(IEntity entity)
		{
			entity.AddDeathEvent(new BaseEvent());
		}

		private void InstallComponents(IEntity entity)
		{
			entity.AddVisualTransform(_visualTransform);
			entity.AddRigidbody2D(_rigidbody);
			entity.AddCollider2D(_collider2D);
			entity.AddTriggerReceiver(_triggerReceiver);
		}

		private void InstallParameters(IEntity entity)
		{
			entity.AddMoveDirection(new ReactiveVariable<Vector2>(_visualTransform.right));
			entity.AddDamage(new ReactiveVariable<int>());
			entity.AddMoveSpeed(new ReactiveVariable<float>(_moveSpeed));

			var lifetimeTimer = new Timer(_lifeDuration);
			lifetimeTimer.Start();
			entity.WhenUpdate(lifetimeTimer.Tick);
			entity.AddLifetimeTimer(lifetimeTimer);
		}

		private static void InstallBehaviours(IEntity entity)
		{
			entity.AddBehaviour<BulletCollisionBehaviour>();
			entity.AddBehaviour<MovementByKinematicRbBehaviour>();
			entity.AddBehaviour<LifetimeBehaviour>();
			entity.AddBehaviour<DestroyEntityOnDeathEventBehaviour>();
		}
	}
}