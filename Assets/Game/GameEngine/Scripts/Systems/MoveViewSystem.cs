using Entitas;
using UnityEngine;

public sealed class MoveViewSystem : IExecuteSystem
{
    private readonly IGroup<GameEntity> _entities;

    public MoveViewSystem(Contexts contexts)
    {
        var matcher = GameMatcher.AllOf(GameMatcher.MoveDirection, GameMatcher.MoveSpeed, GameMatcher.TransformView);
        _entities = contexts.game.GetGroup(matcher);
    }

    public void Execute()
    {
        var deltaTime = Time.deltaTime;
        foreach (var entity in _entities)
        {
            entity.transformView.Value.position += entity.moveDirection.Value * entity.moveSpeed.Value * deltaTime;
            entity.direction.Value = Quaternion.Euler(entity.moveDirection.Value);
        }
    }
}