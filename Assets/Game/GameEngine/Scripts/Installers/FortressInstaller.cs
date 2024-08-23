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
        entity.AddBuildingDamagedParticleSystem(_damagedSmallParticleSystem, _damagedBigParticleSystem);
        entity.isBuilding = true;
    }

    public override void Dispose(GameEntity entity)
    {
    }
}