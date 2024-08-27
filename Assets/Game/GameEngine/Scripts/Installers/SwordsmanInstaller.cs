using UnityEngine;

public sealed class SwordsmanInstaller : EntityInstaller
{
	private const string DEATH_END = "DeathEnd";
	private const string MELEE_ATTACK_START = "MeleeAttackStart";
	private const string MELEE_ATTACK_END = "MeleeAttackEnd";

	[SerializeField]
	private SwordsmanConfig _config;

	[SerializeField]
	private Team _team;
	[SerializeField]
	private Collider _meleeWeaponCollider;
	[SerializeField]
	private Animator _animator;
	[SerializeField]
	private AnimatorDispatcher _animatorDispatcher;
	[SerializeField]
	private SwordCollisionDispatcher _swordCollisionDispatcher;

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
		entity.AddMeleeWeapon(_meleeWeaponCollider, _config.Damage);
		entity.AddAttackTimer(0f);
		entity.isMeleeAttacker = true;
		
		entity.AddTeam(_team);
		entity.AddTypeId("Unit");
		
		entity.AddTransformView(transform);
		entity.AddAnimatorView(_animator);
		entity.isTargetSeeker = true;
		
		_swordCollisionDispatcher.Construct();
		_animatorDispatcher.SubscribeOnEvent(DEATH_END, OnDeathEndEvent);
		_animatorDispatcher.SubscribeOnEvent(MELEE_ATTACK_START, OnMeleeAttackStartEvent);
		_animatorDispatcher.SubscribeOnEvent(MELEE_ATTACK_END, OnMeleeAttackEndEvent);
		_entity = entity;
	}

	private void OnDeathEndEvent()
	{
		_entity.isDelayedDeath = false;
	}

	private void OnMeleeAttackStartEvent()
	{
		_meleeWeaponCollider.enabled = true;
	}

	private void OnMeleeAttackEndEvent()
	{
		_meleeWeaponCollider.enabled = false;
	}

	public override void Dispose(GameEntity entity)
	{
		_animatorDispatcher.UnsubscribeOnEvent(DEATH_END, OnDeathEndEvent);
		_animatorDispatcher.UnsubscribeOnEvent(MELEE_ATTACK_START, OnMeleeAttackStartEvent);
		_animatorDispatcher.UnsubscribeOnEvent(MELEE_ATTACK_END, OnMeleeAttackEndEvent);
		_entity = null;
	}
}