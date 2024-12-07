using System;
using Atomic.Elements;
using Atomic.Entities;
using Atomic.Extensions;
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
		private SpriteRenderer _spriteRenderer;

		[Header("Movement")] [SerializeField]
		private float _moveSpeed;
		[SerializeField]
		private float _jumpForce;
		[SerializeField]
		private Transform _groundCheckTransform;
		[SerializeField]
		private LayerMask _groundLayer;

		[Header("Combat")] 
		// [SerializeField]
		// private SceneEntity _sword;
		[SerializeField]
		private SceneEntity _weapon;
		
		[SerializeField]
		private Transform _weaponContainer;


		[Header("Life")] 
		[SerializeField]
		private int _health;

		[Header("Ability")] 
		[SerializeField]
		private float _dashForce;
		[SerializeField]
		private SceneEntity _stickyBombPrefab;

		private readonly AndExpression _canMove = new();
		private readonly AndExpression _canJump = new();

		public override void Install(IEntity entity)
		{
			entity.AddCharacterTag();
			InitializeLife(entity);
			InitializeMovement(entity);
			InitializeComponents(entity);
			InitializeCombat(entity);
			InitializeAbilities(entity);
		}

		private void InitializeLife(IEntity entity)
		{
			entity.AddHealth(_health);
			entity.AddIsDead(new BaseFunction<bool>(() => entity.GetHealth().Value <= 0));
			entity.AddCanTakeDamage(new AndExpression());
			entity.AddTakeDamageRequest(new BaseEvent<int>());
			entity.AddTakeDamageEvent(new BaseEvent<int>());
			entity.AddDeathEvent(new BaseEvent());

			entity.AddBehaviour(new TakeDamageRequestBehaviour());
			entity.AddBehaviour(new TakeDamageEventBehaviour());
		}

		private void InitializeComponents(IEntity entity)
		{
			entity.AddRigidbody(_rigidBody);
			entity.AddAnimator(_animator);
			entity.AddVisualTransform(_transform);
			entity.AddSpriteRenderer(_spriteRenderer);
		}

		private void InitializeMovement(IEntity entity)
		{
			// State
			entity.AddMoveSpeed(new ReactiveVariable<float>(_moveSpeed));
			entity.AddMoveDirection(new ReactiveVariable<Vector2>());
			// CanMove init
			_canMove.Append(() => true);
			entity.AddCanMove(_canMove);

			// CanJump init
			var distance = ((Vector2)_groundCheckTransform.position - _rigidBody.position).magnitude;
			var isGrounded = new BaseFunction<bool>(() =>
			{
				var i = Physics2D.Raycast(_rigidBody.position, Vector2.down, distance, _groundLayer);
				return i != default;
			});
			entity.AddIsGrounded(isGrounded);

			_canJump.Append(entity.GetIsGrounded());
			entity.AddCanJump(_canJump);
			entity.AddJumpForce(new ReactiveVariable<float>(_jumpForce));
			entity.AddJumpRequest(new BaseEvent());
			entity.AddJumpEvent(new BaseEvent());

			// Behaviours
			entity.AddBehaviour(new MovementByPhysicsBehaviour());
			entity.AddBehaviour(new JumpRequestBehaviour());
			entity.AddBehaviour(new JumpEventBehaviour());
			entity.AddBehaviour(new MovementAnimatorBehaviour());
			entity.AddBehaviour(new JumpVisualBehaviour());
			entity.AddBehaviour(new RotateToTarget2DBehaviour());
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

			// Behaviours
			entity.AddBehaviour(new AttackRequestBehaviour());
			entity.AddBehaviour(new AimWeaponBehaviour());
			entity.AddBehaviour(new EquipWeaponBehaviour());
			entity.AddBehaviour(new UseWeaponOnAttackBehaviour());
		}

		private void InitializeAbilities(IEntity entity)
		{
			// TODO add request and can use
			entity.AddAbilityEvent(new BaseEvent());
			entity.AddActiveAbilityAspects(new ReactiveList<IEntityAspect>());
			entity.AddAbilityCardPickupEvent(new BaseEvent<AbilityCardConfig>());
			entity.AddAbilityInventory(new ReactiveList<AbilityCardState>());
			entity.AddRemoveActiveAbilityEvent(new BaseEvent());

			entity.AddBehaviour(new AbilityPickupBehaviour());
			entity.AddBehaviour(new RemoveActiveAbilityBehaviour());
			entity.AddBehaviour(new AbilityInventoryBehaviour());
		}
	}
}