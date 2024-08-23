using Entitas;

public class BuildingDamagedEventParticleSystem : IExecuteSystem
{
	private readonly IGroup<GameEntity> _entities;

	public BuildingDamagedEventParticleSystem(Contexts contexts)
	{
		var matcher = GameMatcher.AllOf(
            GameMatcher.DamagedEvent, 
            GameMatcher.DamagedParticleSystem, 
            GameMatcher.Building,
            GameMatcher.Health);
		_entities = contexts.game.GetGroup(matcher);
	}

	public void Execute()
	{
		foreach (var entity in _entities.GetEntities())
		{
            var currentHP = entity.health.Current;
            var maxHP = entity.health.Max;
            if (currentHP <= maxHP / 2)
            {
                entity.damagedParticleSystem.Value.Play(); // TODO what to do w/ the heavily damaged
            }			
		}
	}
}