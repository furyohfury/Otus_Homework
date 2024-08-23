using UnityEngine;

public class FortressInstaller : EntityInstaller
{
    [SerializeField]
    private int _health;
    [SerializeField]
    private Team _team;
    [SerializeField]
	private ParticleSystem _damagedParticleSystem;
    
    public override void Install(GameEntity entity)
    {
        entity.AddHealth(_health);
        entity.isDamagableTag = true;
        entity.AddTeam(_team);
        entity.AddDamagedParticleSystem(_damagedParticleSystem);
        entity.isBuilding = true;
    }

    public override void Dispose(GameEntity entity)
    {
    }
}