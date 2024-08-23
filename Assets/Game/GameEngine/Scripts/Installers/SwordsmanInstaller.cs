using UnityEngine;

public sealed class SwordsmanInstaller : EntityInstaller
{
	private const string DEATH_END = "DeathEnd";
	private const string MELEE_ATTACK_START = "MeleeAttackStart";
	private const string MELEE_ATTACK_END = "MeleeAttackEnd";

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
	private Collider _meleeWeapon;
	[SerializeField]
	private Animator _animator;
	[SerializeField]
	private ParticleSystem _damagedParticleSystem;
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
		entity.isMeleeAttacker = true;
		entity.isUnitTag = true;
		entity.AddMeleeWeapon(_meleeWeapon);
		entity.AddUnitDamagedParticleSystem(_damagedParticleSystem);
		_animatorDispatcher.SubscribeOnEvent(DEATH_END, OnDeathEndEvent);
		_animatorDispatcher.SubscribeOnEvent(MELEE_ATTACK_START, OnMeleeAttackStartEvent);
		_animatorDispatcher.SubscribeOnEvent(MELEE_ATTACK_END, OnMeleeAttackEndEvent);
		_entity = entity;
	}


	public void OnDeathEndEvent()
	{
		_entity.isDelayedDeath = false;
	}
	
	private void OnMeleeAttackEndEvent()
	{
		
	}

	private void OnMeleeAttackStartEvent()
	{
		
	}

	public override void Dispose(GameEntity entity)
	{
		_animatorDispatcher.UnsubscribeOnEvent(DEATH_END, OnDeathEndEvent);
		_animatorDispatcher.UnsubscribeOnEvent(MELEE_ATTACK_START, OnMeleeAttackStartEvent);
		_animatorDispatcher.UnsubscribeOnEvent(MELEE_ATTACK_END, OnMeleeAttackEndEvent);
	}
}