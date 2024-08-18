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

    protected internal override void Install(GameEntity entity)
    {
        entity.AddPosition(_transform.position);
        entity.AddDirection(_transform.rotation);
        entity.AddHealth(_health); // todo add config
        entity.AddSpeed(_moveSpeed);
        entity.AddTeam(_team);
        entity.AddTransformView(_transform);
    }

    protected internal override void Dispose(GameEntity entity)
    {
    }
}