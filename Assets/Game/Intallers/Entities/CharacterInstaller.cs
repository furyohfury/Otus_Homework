using System;
using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.Entities
{
	[Serializable]
	public sealed class CharacterInstaller : IEntityInstaller
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
		private ReactiveVariable<float> _moveSpeed;
		[SerializeField]
		private ReactiveVariable<float> _jumpForce;
		[SerializeField]
		private Transform _groundCheckTransform;
		[SerializeField]
		private LayerMask _groundLayer;
		
		[Header("Combat")] [SerializeField]
		private SceneEntity _sword;
		[SerializeField]
		private Transform _firePoint;
		[SerializeField]
		private GameObject _pistolBulletPrefab;
		[SerializeField]
		private GameObject _weapon;
		

		[Header("Life")] [SerializeField]
		private int _health;

		private readonly AndExpression _canMove = new();
		private readonly AndExpression _canJump = new();

		public void Install(IEntity entity)
		{
			InitializeMovement(entity);
			InitializeComponents(entity);
			InitializeCombat(entity);
			InitializeAbilities(entity);
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
			entity.AddMoveSpeed(_moveSpeed);
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
			entity.AddJumpForce(_jumpForce);
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
			entity.AddSword(_sword);
			entity.AddAttackRequest(new BaseEvent());
			entity.AddAttackEvent(new BaseEvent());
			entity.AddCanAttack(new AndExpression());
			entity.AddFirePoint(_firePoint);
			entity.AddPistolBulletPrefab(_pistolBulletPrefab);
			entity.AddWeapon(new ReactiveVariable<GameObject>(_weapon));
			
			entity.AddBehaviour(new AttackBehaviour());
			// entity.AddBehaviour(new SwordAttackAnimationBehaviour());
			entity.AddBehaviour(new PistolShootBehaviour());
			entity.AddBehaviour(new AimWeaponBehaviour());
		}

		private void InitializeLife(IEntity entity)
		{
			entity.AddHealth(_health);
			entity.AddIsDead(new BaseFunction<bool>(() => entity.GetHealth().Value <= 0));
			entity.AddTakeDamageRequest(new BaseEvent<int>());
			entity.AddTakeDamageEvent(new BaseEvent<int>());
			entity.AddDeathEvent(new BaseEvent());

			entity.AddBehaviour(new TakeDamageRequestBehaviour());
			entity.AddBehaviour(new TakeDamageEventBehaviour());
		}

		private void InitializeAbilities(IEntity entity)
		{
			entity.AddAbilityEvent(new BaseEvent());
			entity.AddBehaviour(new JumpAbilityBehaviour());
		}
	}
}