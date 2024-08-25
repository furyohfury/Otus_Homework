using UnityEngine;

public sealed class ArcherInstaller : EntityInstaller
{
	private const string DEATH_END = "DeathEnd";
	private const string BOW_SHOOT = "BowShoot";

	[SerializeField]
	private Transform _transform;
	[SerializeField]
	private int _health;
	[SerializeField]
	private float _moveSpeed;
	[SerializeField]
	private Team _team;
	[SerializeField]
	private float _attackCooldown;
	[SerializeField]
	private float _attackRange;
	[SerializeField]
	private Animator _animator;
	[SerializeField]
	private ParticleSystem _damagedParticleSystem;
	[SerializeField]
	private EntityView _arrow;
	[SerializeField]
	private Transform _firePoint;
	[SerializeField]
	private AnimatorDispatcher _animatorDispatcher;

	private GameEntity _entity;

	public override void Install(GameEntity entity)
	{
		entity.AddPosition(_transform.position);
		entity.AddDirection(_transform.rotation);
		entity.AddHealth(_health, _health); // TODO add config
		entity.isDamagableTag = true;
		entity.AddMoveSpeed(_moveSpeed);
		entity.AddTeam(_team);
		entity.AddTransformView(_transform);
		entity.AddAttackCooldown(_attackCooldown);
		entity.AddAttackTimer(0f);
		entity.AddAttackRange(_attackRange);
		entity.AddAnimatorView(_animator);
		entity.AddUnitDamagedParticleSystem(_damagedParticleSystem);
		entity.isRangeAttacker = true;
		entity.isUnitTag = true;
		entity.AddRangeWeapon(_firePoint, _arrow);
		entity.AddTypeId("Unit");

		_entity = entity;
		_animatorDispatcher.SubscribeOnEvent(DEATH_END, OnDeathEndEvent);
		_animatorDispatcher.SubscribeOnEvent(BOW_SHOOT, OnBowShoot);
	}

	private void OnBowShoot()
	{
		_entity.isShootRequest = true;
	}

	public void OnDeathEndEvent()
	{
		_entity.isDelayedDeath = false;
	}

	public override void Dispose(GameEntity entity)
	{
		_animatorDispatcher.UnsubscribeOnEvent(DEATH_END, OnDeathEndEvent);
		_animatorDispatcher.UnsubscribeOnEvent(BOW_SHOOT, OnBowShoot);
	}
}