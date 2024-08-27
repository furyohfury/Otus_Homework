using Entitas;

public sealed class SpawnPrefabRequestSystem : IExecuteSystem
{
	private readonly IGroup<GameEntity> _entities;
	private readonly EntityManager _entityManager;

	public SpawnPrefabRequestSystem(Contexts contexts, EntityManager manager)
	{
		var matcher = GameMatcher.AllOf(
			GameMatcher.SpawnRequest,
			GameMatcher.Position,
			GameMatcher.Rotation,
			GameMatcher.Prefab);
		_entities = contexts.game.GetGroup(matcher);

		_entityManager = manager;
	}

	public void Execute()
	{
		foreach (var entity in _entities.GetEntities())
		{
			var position = entity.position.Value;
			var rotation = entity.rotation.Value;
			var prefab = entity.prefab.Value;
			EntityView view;
			if (entity.hasTransformView)
			{
				var parentTransform = entity.transformView.Value;
				view = _entityManager.Create(prefab, position, rotation, parentTransform);
			}
			else
			{
				view = _entityManager.Create(prefab, position, rotation);
			}
			entity.Destroy();
		}
	}
}