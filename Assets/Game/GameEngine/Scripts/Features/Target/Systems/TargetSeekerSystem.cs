using Entitas;

public sealed class TargetSeekerSystem : IExecuteSystem
{
	private readonly IGroup<GameEntity> _entities;

	public TargetSeekerSystem(Contexts contexts)
	{
		var matcher = GameMatcher.AllOf(GameMatcher.TargetSeeker)
		                         .NoneOf(GameMatcher.EnemyTarget, GameMatcher.Inactive);
		_entities = contexts.game.GetGroup(matcher);
	}

	public void Execute()
	{
		foreach (var entity in _entities.GetEntities())
		{
			entity.isTargetSearchRequest = true;
		}
	}
}