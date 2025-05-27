using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game
{
	public sealed class AlienEnemyInstaller : SceneEntityInstallerBase
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
		private Transform _weaponContainer;
		[SerializeField]
		private GameObject _worldUI;

		[Header("Movement")] [SerializeField]
		private float _moveSpeed;

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
			InitializeUI(entity);
		}

		private void InitializeLife(IEntity entity)
		{
			entity.AddHealth(new ReactiveVariable<int>(_health));
			entity.AddMaxHealth(new ReactiveVariable<int>(_health));
			entity.AddIsDead(new BaseFunction<bool>(() => entity.GetHealth().Value <= 0));
			entity.AddCanTakeDamage(new AndExpression());
			entity.AddTakeDamageRequest(new BaseEvent<int>());
			entity.AddTakeDamageEvent(new BaseEvent<int>());
			entity.AddDeathRequest(new BaseEvent());
			entity.AddDeathEvent(new BaseEvent());

			entity.AddBehaviour(new TakeDamageRequestBehaviour());
			entity.AddBehaviour(new TakeDamageEventBehaviour());
			entity.AddBehaviour(new DeathRequestBehaviour());
			entity.AddBehaviour(new DeathEventBehaviour());
			entity.AddBehaviour(new DestroyEntityOnDeathBehaviour());
		}

		private void InitializeUnityComponents(IEntity entity)
		{
			entity.AddRigidbody2D(_rigidBody);
			entity.AddAnimator(_animator);
			entity.AddVisualTransform(_transform);
			entity.AddSpriteRenderer(_spriteRenderer);

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

			// Behaviours
			entity.AddBehaviour(new MovementByKinematicRbBehaviour());
			entity.AddBehaviour(new MovementAnimatorBehaviour());
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

			var canAttack = new AndExpression();
			canAttack.Append(() => !entity.GetIsDead().Value);
			entity.AddCanAttack(canAttack);

			// Behaviours
			entity.AddBehaviour(new AttackRequestBehaviour());
			entity.AddBehaviour(new AimWeaponBehaviour());
			entity.AddBehaviour(new UseWeaponOnAttackBehaviour());
			entity.AddBehaviour(new AttackAnimatorBehaviour());
		}

		private void InitializeUI(IEntity entity)
		{
			entity.AddEntityWorldUI(_worldUI);

			entity.AddBehaviour<UIFollowTransformBehaviour>();
		}
	}
}