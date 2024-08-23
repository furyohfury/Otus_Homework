using Entitas;

public class OneFrameCleanupSystem : ICleanupSystem // TODO crutch
{
	private readonly IGroup<GameEntity> _entities;

	public OneFrameCleanupSystem(Contexts contexts)
	{
		var matcher = GameMatcher.AnyOf(GameMatcher.DamagedEvent);
		_entities = contexts.game.GetGroup(matcher);
	}

	public void Cleanup()
	{
		foreach (var entity in _entities.GetEntities())
		{
			entity.isDamagedEvent = false;
		}
	}
}