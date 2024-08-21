using UnityEngine;

public sealed class ProjectileInstaller : EntityInstaller
{
    [SerializeField]
    private Transform _transform;

    [SerializeField]
    private float _moveSpeed;

    [SerializeField]
    private Team _team;

    public override void Install(GameEntity entity)
    {
        // TODO add config
        entity.AddPosition(_transform.position);
        entity.AddDirection(_transform.rotation);
        entity.AddMoveSpeed(_moveSpeed);
        entity.AddMoveDirection(Vector3.forward);
        entity.AddTeam(_team);
        entity.AddTransformView(_transform);
        
    }

    public override void Dispose(GameEntity entity)
    {
    }
}