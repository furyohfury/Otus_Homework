using UnityEngine;

public sealed class SwordsmanInstaller : EntityInstaller
{
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
        _animatorDispatcher.SubscribeOnEvent("DeathEnd", OnDeathEndEvent);
    }

    public void OnDeathEndEvent()
    {
        entity.isDelayedDeath = false
    }

    public override void Dispose(GameEntity entity)
    {
        _animatorDispatcher.UnsubscribeOnEvent("DeathEnd", OnDeathEndEvent);
    }
}