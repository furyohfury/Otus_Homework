using Entitas;
using UnityEngine;

public sealed class LookAtTargetSystem : IExecuteSystem
{
    private readonly IGroup<GameEntity> _entities;

    public LookAtTargetSystem(Contexts contexts)
    {
        var matcher = GameMatcher.AllOf(GameMatcher.Direction, GameMatcher.EnemyTarget, GameMatcher.Position);
        _entities = contexts.game.GetGroup(matcher);
    }

    public void Execute()
    {
        var deltaTime = Time.deltaTime;
        foreach (var entity in _entities.GetEntities())
        {
            var enemyTarget = entity.enemyTarget.Value;
            var lookRot =
                Quaternion.LookRotation(enemyTarget.position.Value - entity.position.Value); // TODO rate in rotation
            entity.direction.Value = Quaternion.Slerp(entity.direction.Value, lookRot, deltaTime * 15f);
        }
    }
}