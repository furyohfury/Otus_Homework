using Entitas;

public class HealthEmptySystem : IExecuteSystem
{
	private readonly IGroup<GameEntity> _entities;

	public HealthEmptySystem(Contexts contexts)
	{
		var matcher = GameMatcher
		              .AllOf(GameMatcher.Health)
		              .NoneOf(GameMatcher.DeathRequest, GameMatcher.Inactive);
		_entities = contexts.game.GetGroup(matcher);
	}


	public void Execute()
	{
		foreach (var entity in _entities.GetEntities())
		{
			if (entity.health.Value <= 0)
			{
				entity.isDeathRequest = true;
			}
		}
	}
}