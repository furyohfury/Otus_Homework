using System.Collections.Generic;
using UnityEngine;

public sealed class EntityManager
{
	private readonly Dictionary<GameEntity, EntityView> _entities = new();
	private Contexts _contexts;
	private Transform _worldTransform;

	public void Initialize(Contexts contexts, Transform worldTransform)
	{
		_worldTransform = worldTransform;
		var entities = Object.FindObjectsOfType<EntityView>();
		for (int i = 0, count = entities.Length; i < count; i++)
		{
			var entityView = entities[i];
			var entity = contexts.game.CreateEntity();
			entityView.Initialize(entity);
			_entities.Add(entity, entityView);
		}

		_contexts = contexts;
	}

	// TODO make poolable by adding parameter bool poolable = false;
	// then make dispose in entity installer where make it ready to return to pool
	public EntityView Create(EntityView prefab, Vector3 position, Quaternion rotation, Transform parent = null)
	{
		var container = parent == null ? _worldTransform : parent;
		var entityView = Object.Instantiate(prefab, position, rotation, container);


		var entity = _contexts.game.CreateEntity();
		entityView.Initialize(entity);
		_entities.Add(entity, entityView);
		return entityView;
	}

	public T CreateNonEntity<T>(T prefab, Vector3 position, Quaternion rotation, Transform parent = null)
		where T : Component
	{
		return Object.Instantiate(prefab, position, rotation, parent);
	}

	public void Destroy(GameEntity entity)
	{
		if (_entities.Remove(entity, out var view))
		{
			view.Dispose();
			Object.Destroy(view.gameObject);
			entity.Destroy();
		}
	}

	public void DestroyNonEntity<T>(T view) where T : Component
	{
		Object.Destroy(view.gameObject);
	}

	public EntityView GetEntityView(GameEntity entity)
	{
		return _entities[entity];
	}
}