using Entitas;

public class UnitDamagedEventParticleSystem : IExecuteSystem
{
	private readonly IGroup<GameEntity> _entities;

	public UnitDamagedEventParticleSystem(Contexts contexts)
	{
		var matcher = GameMatcher.AllOf(
            GameMatcher.DamagedEvent, 
            GameMatcher.DamagedParticleSystem, 
            GameMatcher.Unit);
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