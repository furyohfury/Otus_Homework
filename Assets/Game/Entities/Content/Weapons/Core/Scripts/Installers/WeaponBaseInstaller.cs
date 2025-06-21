using Atomic.Elements;
using Atomic.Entities;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game
{
	public sealed class WeaponBaseInstaller : SceneEntityInstallerBase
	{
		[SerializeField][Required]
		private string _id;
		[SerializeField] [Header("Components")]
		private SpriteRenderer[] _spriteRenderers;
		[SerializeField]
		private Transform _firePoint;
		[SerializeField]
		private SceneEntity _projectilePrefab;
		[SerializeField]
		private Transform _transform;
		[SerializeField][Header("Parameters")]
		private float _attackDelay = 0.3f;
		[SerializeField]
		private int _ammoSize = 10;
		[SerializeField]
		private int _damage = 1;


		public override void Install(IEntity entity)
		{
			entity.AddId(_id);
			entity.AddTag(TagAPI.Weapon);
			InstallShootEvents(entity);
			InstallComponents(entity);
			InstallWeaponParameters(entity);
			InstallShootConditions(entity);
			InstallBehaviours(entity);
		}

		private void InstallComponents(IEntity entity)
		{
			entity.AddSpriteRenderers(_spriteRenderers);
			entity.AddVisualTransform(_transform);
			entity.AddFirePoint(new ReactiveVariable<Transform>(_firePoint));
			entity.AddProjectilePrefab(new ReactiveVariable<SceneEntity>(_projectilePrefab));
		}

		private void InstallWeaponParameters(IEntity entity)
		{
			entity.AddDamage(new ReactiveVariable<int>(_damage));
			entity.AddAttackDelay(new ReactiveVariable<float>(_attackDelay));
			entity.AddAmmoSize(new ReactiveVariable<int>(_ammoSize));
			entity.AddAmmo(new ReactiveVariable<int>(_ammoSize));
		}

		private void InstallShootConditions(IEntity entity)
		{
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

		private void InstallShootEvents(IEntity entity)
		{
			entity.AddAttackRequest(new BaseEvent());
			entity.AddAttackEvent(new BaseEvent());
		}

		private void InstallBehaviours(IEntity entity)
		{
			entity.AddBehaviour<AttackRequestBehaviour>();
			entity.AddBehaviour<SingleBulletWeaponBehaviour>();
			entity.AddBehaviour<SpendAmmoOnAttackBehaviour>();
		}
	}
}