using Atomic.Elements;
using Atomic.Entities;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game
{
	public sealed class EnemyBaseInstaller : SceneEntityInstallerBase
	{
		[SerializeField] [Required]
		private string _id;
		[SerializeField] [Header("Components")]
		private Rigidbody2D _rigidBody;
		[SerializeField]
		private Animator _animator;
		[SerializeField]
		private AnimatorEventReceiver _animatorEventReceiver;
		[SerializeField]
		private Transform _transform;
		[SerializeField]
		private Transform _weaponContainer;
		[SerializeField]
		private SpriteRenderer[] _spriteRenderers;
		[SerializeField]
		private SceneEntity _weapon;

		[SerializeField] [Header("Parameters")]
		private float _moveSpeed;
		[SerializeField]
		private int _health;

		public override void Install(IEntity entity)
		{
			entity.AddId(_id);
			entity.AddEnemyTag();
			InitLifeState(entity);
			InitMovementState(entity);
			InitComponentsState(entity);
			InitCombatState(entity);

			InitLifeBehaviours(entity);
			InitMovementBehaviours(entity);
			InitComponentsBehaviour(entity);
			InitCombatBehaviours(entity);
		}

		private void InitLifeState(IEntity entity)
		{
			entity.AddHealth(new ReactiveVariable<int>(_health));
			entity.AddMaxHealth(new ReactiveVariable<int>(_health));
			entity.AddIsDead(new BaseFunction<bool>(() => entity.GetHealth().Value <= 0));
			entity.AddCanTakeDamage(new AndExpression());
			entity.AddTakeDamageRequest(new BaseEvent<int>());
			entity.AddTakeDamageEvent(new BaseEvent<int>());
			entity.AddDeathRequest(new BaseEvent());
			entity.AddDeathEvent(new BaseEvent());
		}

		private void InitMovementState(IEntity entity)
		{
			entity.AddMoveSpeed(new ReactiveVariable<float>(_moveSpeed));
			entity.AddMoveDirection(new ReactiveVariable<Vector2>());
			// CanMove init
			var canMove = new AndExpression();
			canMove.Append(new BaseFunction<bool>(() => entity.GetIsDead().Value == false));
			entity.AddCanMove(canMove);
		}

		private void InitComponentsState(IEntity entity)
		{
			entity.AddRigidbody2D(_rigidBody);
			entity.AddAnimator(_animator);
			entity.AddVisualTransform(_transform);
			entity.AddSpriteRenderers(_spriteRenderers);
			entity.AddAnimatorEventReceiver(_animatorEventReceiver);
		}

		private void InitCombatState(IEntity entity)
		{
			entity.AddAttackRequest(new BaseEvent());
			entity.AddAttackEvent(new BaseEvent());
			entity.AddWeaponContainer(_weaponContainer);
			if (_weapon != null)
			{
				entity.AddWeapon(new ReactiveVariable<SceneEntity>(_weapon));
			}

			var canAttack = new AndExpression();
			canAttack.Append(() => !entity.GetIsDead().Value);
			entity.AddCanAttack(canAttack);
		}

		private static void InitLifeBehaviours(IEntity entity)
		{
			entity.AddBehaviour<TakeDamageRequestBehaviour>();
			entity.AddBehaviour<TakeDamageEventBehaviour>();
			entity.AddBehaviour<DeathRequestBehaviour>();
			entity.AddBehaviour<DeathStopAnimatorBehaviour>();
			entity.AddBehaviour<DisablePhysicsOnDeathRequestBehaviour>();
			entity.AddBehaviour<DisableSpritesOnDeathRequestBehaviour>();
			entity.AddBehaviour<DeactivateEntityOnDeathBehaviour>();
		}

		private static void InitMovementBehaviours(IEntity entity)
		{
			entity.AddBehaviour<MovementAnimatorBehaviour>();
			entity.AddBehaviour<RotateToTarget2DBehaviour>();
		}

		private static void InitComponentsBehaviour(IEntity entity)
		{
			entity.AddBehaviour<DisableAnimatorBehaviour>();
		}

		private static void InitCombatBehaviours(IEntity entity)
		{
			entity.AddBehaviour<AttackRequestBehaviour>();
			entity.AddBehaviour<UseWeaponOnAttackBehaviour>();
			entity.AddBehaviour<AttackAnimatorBehaviour>();
		}
	}
}