using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game
{
	public class MachineGunInstaller : SceneEntityInstallerBase
	{
		[SerializeField]
		private SpriteRenderer _spriteRenderer;
		[SerializeField]
		private Transform _firePoint;
		[SerializeField]
		private SceneEntity _projectilePrefab;
		[SerializeField]
		private Transform _transform;
		[SerializeField]
		private float _attackDelay = 0.3f;
		[SerializeField]
		private int _ammoSize = 10;
		[SerializeField]
		private int  _damage = 1;
		[SerializeField]
		private float _spreadAngle;


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
			entity.AddDamage(new ReactiveVariable<int>(_damage));
			entity.AddWeaponSpreadAngle(new ReactiveVariable<float>(_spreadAngle));
			entity.AddFirePoint(new ReactiveVariable<Transform>(_firePoint));
			entity.AddAttackDelay(new ReactiveVariable<float>(_attackDelay));
			entity.AddProjectilePrefab(new ReactiveVariable<SceneEntity>(_projectilePrefab));
			entity.AddAmmoSize(new ReactiveVariable<int>(_ammoSize));
			entity.AddAmmo(new ReactiveVariable<int>(_ammoSize));

			var attackTimer = new Timer(_attackDelay);
			entity.WhenUpdate(attackTimer.Tick);
			entity.GetAttackEvent().Subscribe(() => attackTimer.Start());
			entity.AddAttackTimer(attackTimer);
			var timerEnded = new OrExpression();
			timerEnded.Append(entity.GetAttackTimer().IsEnded);
			timerEnded.Append(entity.GetAttackTimer().IsIdle);

			var canAttack = new AndExpression();
			canAttack.Append(timerEnded);
			canAttack.Append(() => entity.GetAmmo().Value > 0);
			entity.AddCanAttack(canAttack);
		}

		private void InstallInteractions(IEntity entity)
		{
			entity.AddAttackRequest(new BaseEvent());
			entity.AddAttackEvent(new BaseEvent());
		}

		private void InstallBehaviours(IEntity entity)
		{
			entity.AddBehaviour<AttackRequestBehaviour>();
			entity.AddBehaviour<SpreadShootBehaviour>();
			entity.AddBehaviour<SpendAmmoOnAttackBehaviour>();
		}
	}
}