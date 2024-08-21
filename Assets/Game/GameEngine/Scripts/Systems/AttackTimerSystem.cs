using Entitas;
using UnityEngine;

public sealed class AttackTimerSystem : IExecuteSystem
{
    private readonly IGroup<GameEntity> _entities;

    public AttackTimerSystem(Contexts contexts)
    {
        var matcher = GameMatcher.AllOf(GameMatcher.AttackTimer, GameMatcher.AttackCooldown);
        _entities = contexts.game.GetGroup(matcher);
    }

    public void Execute()
    {
        var deltaTime = Time.deltaTime;
        foreach (var entity in _entities.GetEntities())
        {
            if (entity.attackTimer.Value > 0)
            {
                entity.attackTimer.Value -= deltaTime;
            }
        }
    }
}