using Entitas;

public class DeathRequestSystem : IExecuteSystem
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
		foreach (var entity in _entities.GetEntities())
		{
			entity.isInactive = true;
			entity.isDeathEvent = true;
			entity.isDeathRequest = false;
		}
	}
}