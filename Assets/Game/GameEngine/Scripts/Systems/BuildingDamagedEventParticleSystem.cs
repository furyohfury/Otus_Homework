using Entitas;

public class BuildingDamagedEventParticleSystem : IExecuteSystem
{
	private readonly IGroup<GameEntity> _entities;

	public BuildingDamagedEventParticleSystem(Contexts contexts)
	{
		var matcher = GameMatcher.AllOf(
            GameMatcher.DamagedEvent, 
            GameMatcher.DamagedParticleSystem, 
            GameMatcher.Building);
		_entities = contexts.game.GetGroup(matcher);
	}

	public void Execute()
	{
		foreach (var entity in _entities.GetEntities())
		{
			entity.damagedParticleSystem.Value.Play();
		}
	}
}