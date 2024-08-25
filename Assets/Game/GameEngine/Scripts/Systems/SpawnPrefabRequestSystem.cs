using Entitas;

public sealed class SpawnPrefabRequestSystem : IExecuteSystem, ICleanupSystem
{
	private readonly IGroup<GameEntity> _entities;
	private readonly EntityManager _entityManager;

	public SpawnPrefabRequestSystem(Contexts contexts, EntityManager manager)
	{
		var matcher = GameMatcher.AllOf(
			GameMatcher.SpawnRequest,
			GameMatcher.Position,
			GameMatcher.Direction,
			GameMatcher.Prefab);
		_entities = contexts.game.GetGroup(matcher);

		_entityManager = manager;
	}

	public void Execute()
	{
		foreach (var entity in _entities.GetEntities())
		{
			var position = entity.position.Value;
			var rotation = entity.direction.Value;
			var prefab = entity.prefab.Value;

			_entityManager.Create(prefab, position, rotation);
		}
	}

	public void Cleanup()
	{
		foreach (var entity in _entities.GetEntities())
		{
			entity.Destroy();
		}
	}
}