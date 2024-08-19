using Entitas;
using UnityEngine;

public sealed class TargetDeadSystem : IExecuteSystem
{
    private readonly IGroup<GameEntity> _entities;

    public TargetDeadSystem(Contexts contexts)
    {
        _entities = contexts.game.GetGroup(GameMatcher.Target);
    }

    public void Execute()
    {
        foreach (var entity in _entities.GetEntities())
        {
            if (entity.target.Value != Vector3.zero)
            {
                entity.RemoveTarget();
            }
        }
    }
}