using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.Entities
{
	public sealed class LizardStickWeaponInstaller : SceneEntityInstallerBase
	{
		[SerializeField]
		private Transform _transform;
		[SerializeField]
		private TriggerReceiver _triggerReceiver;
		[SerializeField]
		private Collider2D _collider2D;
		[SerializeField]
		private int _damage;
		[SerializeField]
		private SpriteRenderer _spriteRenderer;
		[SerializeField]
		private float _attackDelay;
		[SerializeField]
		private int _ammo;

		public override void Install(IEntity entity)
		{
			InstallInteractions(entity);
			InstallComponents(entity);
			InstallWeaponParameters(entity);
			InstallBehaviours(entity);
		}

		private void InstallComponents(IEntity entity)
		{
			entity.AddSpriteRenderer(_spriteRenderer);
			entity.AddVisualTransform(_transform);
		}

		private void InstallWeaponParameters(IEntity entity)
		{
			// Old
			entity.AddTriggerReceiver(_triggerReceiver);
			entity.AddTriggerEnterEvent(new BaseEvent<Collider2D>());
			entity.AddTriggerExitEvent(new BaseEvent<Collider2D>());
			entity.AddCollider2D(_collider2D);

			entity.AddBehaviour(new MeleeWeaponCollisionBehaviour());

			// New
			entity.AddDamage(new ReactiveVariable<int>(_damage));
			entity.AddAttackDelay(new ReactiveVariable<float>(_attackDelay));
			entity.AddAmmo(new ReactiveVariable<int>(_ammo));
			entity.AddAmmoSize(new ReactiveVariable<int>(_ammo));

			var attackTimer = new Timer(_attackDelay);
			entity.WhenUpdate(attackTimer.Tick);
			entity.GetAttackEvent().Subscribe(() => attackTimer.Start());
			entity.AddAttackTimer(attackTimer);
			var timerEnded = new OrExpression();
			timerEnded.Append(entity.GetAttackTimer().IsEnded);
			timerEnded.Append(entity.GetAttackTimer().IsIdle);

			var canAttack = new AndExpression();
			canAttack.Append(timerEnded);
			entity.AddCanAttack(canAttack);
		}

		private void InstallInteractions(IEntity entity)
		{
			entity.AddAttackRequest(new BaseEvent());
			entity.AddAttackEvent(new BaseEvent());
			entity.AddActivateColliderEvent(new BaseEvent());
			entity.AddDeactivateColliderEvent(new BaseEvent());
		}

		private void InstallBehaviours(IEntity entity)
		{
			entity.AddBehaviour<AttackRequestBehaviour>();
			entity.AddBehaviour<MeleeWeaponCollisionBehaviour>();
			entity.AddBehaviour<MeleeWeaponColliderActivationBehaviour>();
		}
	}
}