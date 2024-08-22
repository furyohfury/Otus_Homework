using Entitas;

public class DestroyGOSystem : IExecuteSystem
{
	private readonly IGroup<GameEntity> _entities;
	private EntityManager _entityManager;

	public DestroyGOSystem(Contexts contexts)
	{
		var matcher = GameMatcher.AllOf(GameMatcher.Inactive).NoneOf(GameMatcher.DelayedDeath);
		_entities = contexts.game.GetGroup(matcher);
	}

	public void Execute()
	{
		foreach (var entity in _entities)
		{
			_entityManager.Destroy(entity);
		}
	}
}