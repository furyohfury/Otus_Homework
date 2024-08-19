using UnityEngine;
using UnityEngine.Serialization;

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

    public override void Install(GameEntity entity)
    {
        entity.AddPosition(_transform.position);
        entity.AddDirection(_transform.rotation);
        entity.AddHealth(_health); // todo add config
        entity.AddMoveSpeed(_moveSpeed);
        entity.AddTeam(_team);
        entity.AddTransformView(_transform);
        entity.AddAttackTimer(_attackCooldown);
        entity.AddAttackRange(_attackRange);
    }

    public override void Dispose(GameEntity entity)
    {
    }
}