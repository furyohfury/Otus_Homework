using System.Collections.Generic;
using UnityEngine;

public sealed class EntityManager
{
    private readonly Dictionary<GameEntity, EntityView> _entities = new();
    private Contexts _contexts;

    public void Initialize(Contexts contexts)
    {
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

    public EntityView Create(EntityView prefab, Vector3 position, Quaternion rotation, Transform parent = null)
    {
        var entityView = Object.Instantiate(prefab, position, rotation, parent);
        var entity = _contexts.game.CreateEntity();
        entityView.Initialize(entity);
        _entities.Add(entity, entityView);
        return entityView;
    }

    public void Destroy(GameEntity entity)
    {
        if (_entities.Remove(entity, out var view))
        {
            view.Dispose();
            Object.Destroy(view.gameObject);
        }
    }

    public EntityView GetView(GameEntity entity)
    {
        return _entities[entity];
    }
}