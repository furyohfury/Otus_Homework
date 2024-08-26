using Entitas;

public class RenderPositionSystem : IExecuteSystem
{
	private readonly IGroup<GameEntity> _entities;

	public RenderPositionSystem(Contexts contexts)
	{
		var matcher = GameMatcher.AllOf(GameMatcher.TransformView, GameMatcher.Position, GameMatcher.Rotation);
		_entities = contexts.game.GetGroup(matcher);
	}

	public void Execute()
	{
		foreach (var entity in _entities.GetEntities())
		{
			entity.transformView.Value.position = entity.position.Value;
			entity.transformView.Value.rotation = entity.rotation.Value;
		}
	}
}