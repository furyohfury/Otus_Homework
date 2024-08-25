using UnityEngine;

public class FortressInstaller : EntityInstaller
{
    [SerializeField]
    private int _health;
    [SerializeField]
    private Team _team;
    
    public override void Install(GameEntity entity)
    {
        entity.AddHealth(_health, _health);
        entity.isDamagableTag = true;
        entity.AddTeam(_team);
        entity.AddPosition(transform.position);
        entity.AddDirection(transform.rotation);
        entity.AddTypeId("Building");
        entity.AddTransformView(transform);
    }

    public override void Dispose(GameEntity entity)
    {
    }
}