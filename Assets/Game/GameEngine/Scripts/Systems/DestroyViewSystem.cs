using Entitas;

public class DestroyViewSystem : IExecuteSystem
{
	private readonly IGroup<GameEntity> _entities;
	private EntityManager _entityManager;

	public DestroyViewSystem(Contexts contexts, EntityManager entityManager)
	{
		var matcher = GameMatcher.AllOf(GameMatcher.Inactive).NoneOf(GameMatcher.DelayedDeath);
		_entities = contexts.game.GetGroup(matcher);
		_entityManager = entityManager;
	}

	public void Execute()
	{
		foreach (var entity in _entities)
		{
			_entityManager.Destroy(entity);
		}
	}
}