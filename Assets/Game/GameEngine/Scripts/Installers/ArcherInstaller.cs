using UnityEngine;

public sealed class ArcherInstaller : EntityInstaller
{
	private const string DEATH_END = "DeathEnd";
	private const string BOW_SHOOT = "BowShoot";

	[SerializeField]
	private ArcherConfig _config;
	
	[SerializeField]
	private Team _team;
	[SerializeField]
	private Animator _animator;
	[SerializeField]
	private AnimatorDispatcher _animatorDispatcher;
	[SerializeField]
	private ParticleSystem _damagedParticleSystem;
	[SerializeField]
	private EntityView _arrow;
	[SerializeField]
	private Transform _firePoint;

	private GameEntity _entity;

	public override void Install(GameEntity entity)
	{
		entity.AddPosition(transform.position);
		entity.AddRotation(transform.rotation);
		entity.AddRotationRate(_config.RotationRate);
		entity.AddMoveSpeed(_config.MoveSpeed);
		
		entity.AddHealth(_config.Health, _config.Health);
		entity.isDamagableTag = true;
		
		entity.AddAttackRange(_config.AttackRange);
		entity.AddAttackCooldown(_config.AttackCooldown);
		entity.AddAttackTimer(0f);
		entity.isRangeAttacker = true;
		entity.AddRangeWeapon(_firePoint, _arrow);
		
		entity.AddTeam(_team);
		entity.AddTypeId("Unit");
		entity.isTargetSeeker = true;
		
		entity.AddTransformView(transform);
		entity.AddAnimatorView(_animator);

		_entity = entity;
		_animatorDispatcher.SubscribeOnEvent(DEATH_END, OnDeathEndEvent);
		_animatorDispatcher.SubscribeOnEvent(BOW_SHOOT, OnBowShoot);
	}

	private void OnBowShoot()
	{
		_entity.isShootRequest = true;
	}

	private void OnDeathEndEvent()
	{
		_entity.isDelayedDeath = false;
	}

	public override void Dispose(GameEntity entity)
	{
		_animatorDispatcher.UnsubscribeOnEvent(DEATH_END, OnDeathEndEvent);
		_animatorDispatcher.UnsubscribeOnEvent(BOW_SHOOT, OnBowShoot);
	}
}