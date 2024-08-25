using UnityEngine;

public class FortressInstaller : EntityInstaller
{
    [SerializeField]
    private int _health;
    [SerializeField]
    private Team _team;
    [SerializeField]
	private ParticleSystem _damagedSmallParticleSystem;
    [SerializeField]
	private ParticleSystem _damagedBigParticleSystem;
    
    public override void Install(GameEntity entity)
    {
        entity.AddHealth(_health, _health);
        entity.isDamagableTag = true;
        entity.AddTeam(_team);
        entity.isBuildingTag = true;
        entity.AddPosition(transform.position);
        entity.AddTypeId("Building");
        entity.AddDirection(transform.rotation);
        entity.AddTransformView(transform);
    }

    public override void Dispose(GameEntity entity)
    {
    }
}