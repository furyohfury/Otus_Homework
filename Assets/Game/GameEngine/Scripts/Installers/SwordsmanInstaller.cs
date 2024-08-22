using UnityEngine;

public sealed class SwordsmanInstaller : EntityInstaller
{
	private const string DEATH_END = "DeathEnd";
	
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
	private AnimatorDispatcher _animatorDispatcher;

	private GameEntity _entity;

	public override void Install(GameEntity entity)
	{
		entity.AddPosition(_transform.position);
		entity.AddDirection(_transform.rotation);
		entity.AddHealth(_health); // TODO add config
		entity.isDamagableTag = true;
		entity.AddMoveSpeed(_moveSpeed);
		entity.AddTeam(_team);
		entity.AddTransformView(_transform);
		entity.AddAttackCooldown(_attackCooldown);
		entity.AddAttackTimer(0f);
		entity.AddAttackRange(_attackRange);
		entity.AddAnimatorView(_animator);
		entity.isMeleeAttacker = true;
		_animatorDispatcher.SubscribeOnEvent(DEATH_END, OnDeathEndEvent);
		_entity = entity;
	}

	public void OnDeathEndEvent()
	{
		_entity.isDelayedDeath = false;
	}

	public override void Dispose(GameEntity entity)
	{
		_animatorDispatcher.UnsubscribeOnEvent(DEATH_END, OnDeathEndEvent);
	}
}