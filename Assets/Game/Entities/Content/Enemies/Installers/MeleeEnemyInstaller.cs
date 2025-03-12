using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game
{
	public sealed class MeleeEnemyInstaller : SceneEntityInstallerBase
	{
		[SerializeField]
		private string _id;
		[Header("Components")]
		[SerializeField]
		private Rigidbody2D _rigidBody;
		[SerializeField]
		private Animator _animator;
		[SerializeField]
		private Transform _transform;
		[SerializeField]
		private SpriteRenderer _spriteRenderer;
		[SerializeField]
		private AnimatorEventReceiver _animatorEventReceiver;

		[Header("Movement")] [SerializeField]
		private float _moveSpeed;
		[SerializeField]
		private Transform _groundCheckTransform;
		[SerializeField]
		private LayerMask _groundLayer;

		[Header("Combat")]
		[SerializeField]
		private SceneEntity _weapon;

		[Header("Life")]
		[SerializeField]
		private int _health;

		private readonly AndExpression _canMove = new();

		public override void Install(IEntity entity)
		{
			entity.AddEnemyTag();
			entity.AddId(_id);
			InitializeLife(entity);
			InitializeMovement(entity);
			InitializeUnityComponents(entity);
			InitializeCombat(entity);
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

			entity.AddBehaviour(new TakeDamageRequestBehaviour());
			entity.AddBehaviour(new TakeDamageEventBehaviour());
			entity.AddBehaviour(new DeathRequestBehaviour());
			entity.AddBehaviour(new DeathStopAnimatorBehaviour());
			entity.AddBehaviour(new DeathEventBehaviour());
			entity.AddBehaviour(new DestroyEntityOnDeathBehaviour());
		}

		private void InitializeUnityComponents(IEntity entity)
		{
			entity.AddRigidbody2D(_rigidBody);
			entity.AddAnimator(_animator);
			entity.AddVisualTransform(_transform);
			entity.AddSpriteRenderer(_spriteRenderer);
			entity.AddAnimatorEventReceiver(_animatorEventReceiver);
			
			entity.AddBehaviour<DisableAnimatorBehaviour>();
		}

		private void InitializeMovement(IEntity entity)
		{
			// State
			entity.AddMoveSpeed(new ReactiveVariable<float>(_moveSpeed));
			entity.AddMoveDirection(new ReactiveVariable<Vector2>());
			// CanMove init
			_canMove.Append(new BaseFunction<bool>(() => entity.GetIsDead().Value == false));
			entity.AddCanMove(_canMove);
			var distance = ((Vector2)_groundCheckTransform.position - _rigidBody.position).magnitude;
			var isGrounded = new BaseFunction<bool>(() =>
			{
				var i = Physics2D.Raycast(_rigidBody.position, Vector2.down, distance, _groundLayer);
				return i != default;
			});
			entity.AddIsGrounded(isGrounded);

			// Behaviours
			entity.AddBehaviour(new MovementByPhysicsBehaviour());
			entity.AddBehaviour(new MovementAnimatorBehaviour());
			entity.AddBehaviour(new RotateToTarget2DBehaviour());
		}

		private void InitializeCombat(IEntity entity)
		{
			// State
			entity.AddAttackRequest(new BaseEvent());
			entity.AddAttackEvent(new BaseEvent());
			if (_weapon != null)
			{
				entity.AddWeapon(new ReactiveVariable<SceneEntity>(_weapon));
			}

			var canAttack = new AndExpression();
			canAttack.Append(() => !entity.GetIsDead().Value);
			entity.AddCanAttack(canAttack);

			// Behaviours
			entity.AddBehaviour(new AttackRequestBehaviour());
			entity.AddBehaviour(new UseWeaponOnAttackBehaviour());
			entity.AddBehaviour(new AttackAnimatorBehaviour());
			entity.AddBehaviour<MeleeWeaponHitByAnimatorBehaviour>();
		}
	}
}