using Entitas;
using UnityEngine;

public sealed class MoveSystem : IExecuteSystem
{
    private readonly IGroup<GameEntity> _entities;

    public MoveSystem(Contexts contexts)
    {
        var matcher = GameMatcher.AllOf(GameMatcher.MoveDirection, GameMatcher.MoveSpeed, GameMatcher.Position);
        _entities = contexts.game.GetGroup(matcher);
    }

    public void Execute()
    {
        var deltaTime = Time.deltaTime;
        foreach (var entity in _entities)
        {
            entity.position.Value += entity.moveDirection.Value.normalized * entity.moveSpeed.Value * deltaTime;
            var lookRot = Quaternion.LookRotation(entity.moveDirection.Value);
            entity.direction.Value = Quaternion.Slerp(entity.direction.Value, lookRot, deltaTime * 0.3f); // TODO rate in rotation
        }
    }
}