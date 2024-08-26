using Entitas;

public class EventsDeleteSystem : ICleanupSystem
{
	private readonly IGroup<GameEntity> _entities;

	public EventsDeleteSystem(Contexts contexts)
	{
		var matcher = GameMatcher.AnyOf(GameMatcher.DamagedEvent,
			GameMatcher.MeleeAttackEvent,
			GameMatcher.RangeAttackEvent);
		_entities = contexts.game.GetGroup(matcher);
	}

	public void Cleanup()
	{
		foreach (var entity in _entities.GetEntities())
		{
			entity.isDamagedEvent = false;
			entity.isMeleeAttackEvent = false;
			entity.isRangeAttackEvent = false;
			entity.isDeathEvent = false;
		}
	}
}