using UnityEngine;

public class FortressInstaller : EntityInstaller
{
    [SerializeField]
    private int _health;

    [SerializeField]
    private Team _team;
    
    public override void Install(GameEntity entity)
    {
        entity.AddHealth(_health);
        entity.isDamagableTag = true;
        entity.AddTeam(_team);
    }

    public override void Dispose(GameEntity entity)
    {
    }
}