using Entitas;

public class DeathRequestSystem : IExecuteSystem, ICleanupSystem
{
	private readonly IGroup<GameEntity> _entities;

	public DeathRequestSystem(Contexts contexts)
	{
		var matcher = GameMatcher
            .AllOf(GameMatcher.DeathRequest)
            .NoneOf(GameMatcher.Inactive);
		_entities = contexts.game.GetGroup(matcher);
	}


	public void Execute()
	{
		foreach (var entity in _entities)
		{
			entity.isInactive = true;
            entity.isDeathEvent = true;
		}
	}

    public void Cleanup()
	{
		foreach (var entity in _entities)
		{			
            entity.isDeathRequest = false;
		}
	}
}