using System;
using Atomic.Elements;
using Atomic.Entities;
using Atomic.Extensions;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Entities
{
	[Serializable]
	public sealed class CharacterInstaller : SceneEntityInstallerBase
	{
		[Header("Components")]
		[SerializeField]
		private Rigidbody2D _rigidBody;
		[SerializeField]
		private Animator _animator;
		[SerializeField]
		private Transform _transform;
		[SerializeField]
		private LineRenderer _aimLine;
		[SerializeField]
		private SpriteRenderer[] _spriteRenderers;

		[Header("Movement")] [SerializeField]
		private float _moveSpeed;
		[SerializeField]
		private float _jumpForce;
		[SerializeField]
		private Transform _groundCheckTransform;
		[SerializeField]
		private LayerMask _groundLayer;

		[Header("Combat")]
		[SerializeField]
		private SceneEntity _weapon;

		[SerializeField]
		private Transform _weaponContainer;

		[Header("Life")]
		[SerializeField]
		private int _health;

		private float _groundCheckPointOffset;

		public override void Install(IEntity entity)
		{
			entity.AddCharacterTag();
			InitializeLife(entity);
			InitializeMovement(entity);
			InitializeUnityComponents(entity);
			InitializeCombat(entity);
			InitializeAbilities(entity);
		}

		private void InitializeLife(IEntity entity)
		{
			entity.AddHealth(new ReactiveVariable<int>(_health));
			entity.AddIsDead(new BaseFunction<bool>(() => entity.GetHealth().Value <= 0));
			entity.AddCanTakeDamage(new AndExpression());
			entity.AddTakeDamageRequest(new BaseEvent<int>());
			entity.AddTakeDamageEvent(new BaseEvent<int>());
			entity.AddDeathRequest(new BaseEvent());
			entity.AddDeathEvent(new BaseEvent());

			entity.AddBehaviour<TakeDamageRequestBehaviour>();
			entity.AddBehaviour<TakeDamageEventBehaviour>();
			entity.AddBehaviour<DeathRequestBehaviour>();
			entity.AddBehaviour<DeathRequestBehaviour>();
			entity.AddBehaviour<DeathStopAnimatorBehaviour>();
			entity.AddBehaviour<DeathSFXBehaviour>();
		}

		private void InitializeUnityComponents(IEntity entity)
		{
			entity.AddRigidbody2D(_rigidBody);
			entity.AddAnimator(_animator);
			entity.AddVisualTransform(_transform);
			entity.AddSpriteRenderers(_spriteRenderers);

			entity.AddBehaviour<DisableAnimatorBehaviour>();
		}

		private void InitializeMovement(IEntity entity)
		{
			// State
			entity.AddMoveSpeed(new ReactiveVariable<float>(_moveSpeed));
			entity.AddMoveDirection(new ReactiveVariable<Vector2>());
			// CanMove init
			var canMove = new AndExpression();
			canMove.Append(() => entity.GetIsDead().Value == false);
			entity.AddCanMove(canMove);

			// CanJump init
			_groundCheckPointOffset = ((Vector2)_groundCheckTransform.position - _rigidBody.position).magnitude;
			var isGrounded = new BaseFunction<bool>(() =>
			{
				RaycastHit2D hit = Physics2D.Raycast(
					_rigidBody.position,
					Vector2.down,
					_groundCheckPointOffset,
					_groundLayer);
				return hit != default;
			});
			entity.AddIsGrounded(isGrounded);

			var canJump = new AndExpression();
			canJump.Append(() => entity.GetIsDead().Value == false);
			canJump.Append(entity.GetIsGrounded().Invoke);
			entity.AddCanJump(canJump);
			entity.AddJumpForce(new ReactiveVariable<float>(_jumpForce));
			entity.AddJumpRequest(new BaseEvent());
			entity.AddJumpEvent(new BaseEvent());

			// Behaviours
			entity.AddBehaviour<MovementByPhysicsAxisXBehaviour>();
			entity.AddBehaviour<JumpRequestBehaviour>();
			entity.AddBehaviour<JumpEventBehaviour>();
			entity.AddBehaviour<MovementAnimatorBehaviour>();
			entity.AddBehaviour<JumpVisualBehaviour>();
			entity.AddBehaviour<RotateToTarget2DBehaviour>();
		}

		private void InitializeCombat(IEntity entity)
		{
			// State
			entity.AddAttackRequest(new BaseEvent());
			entity.AddAttackEvent(new BaseEvent());
			entity.AddWeaponContainer(_weaponContainer);
			if (_weapon != null)
			{
				entity.AddWeapon(new ReactiveVariable<SceneEntity>(_weapon));
			}

			entity.AddEquipWeaponRequest(new BaseEvent<SceneEntity>());
			entity.AddUnequipWeaponRequest(new BaseEvent());

			var canAttack = new AndExpression();
			canAttack.Append(() => !entity.GetIsDead().Value);
			entity.AddCanAttack(canAttack);
			entity.AddAimLine(_aimLine);

			// Behaviours
			entity.AddBehaviour<AttackRequestBehaviour>();
			entity.AddBehaviour<AimWeaponBehaviour>();
			entity.AddBehaviour<EquipWeaponBehaviour>();
			entity.AddBehaviour<UseWeaponOnAttackBehaviour>();
			entity.AddBehaviour<WeaponAimLineBehaviour>();
		}

		private void InitializeAbilities(IEntity entity)
		{
			entity.AddAbilityRequest(new BaseEvent());
			var canUseAbility = new AndExpression();
			canUseAbility.Append(() => !entity.GetIsDead().Value);
			entity.AddCanUseAbility(canUseAbility);
			entity.AddAbilityEvent(new BaseEvent());
			entity.AddActiveAbilityAspects(new ReactiveList<IEntityAspect>());
			entity.AddAbilityCardPickupEvent(new BaseEvent<AbilityCardConfig>());
			entity.AddAbilityInventory(new ReactiveList<AbilityCardState>());
			entity.AddRemoveActiveAbilityEvent(new BaseEvent());

			entity.AddBehaviour<AbilityPickupBehaviour>();
			entity.AddBehaviour<RemoveActiveAbilityBehaviour>();
			entity.AddBehaviour<AbilityInventoryBehaviour>();
			entity.AddBehaviour<AbilityRequestBehaviour>();
		}

		[Button]
		private void CollectSpriteRenderers()
		{
			_spriteRenderers = GetComponentsInChildren<SpriteRenderer>();
		}
	}
}