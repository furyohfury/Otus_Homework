﻿using Entitas;

public sealed class TargetInRangeSystem : IExecuteSystem
{
    private readonly IGroup<GameEntity> _entities;

    public TargetInRangeSystem(Contexts contexts)
    {
        var matcher = GameMatcher.AllOf(
            GameMatcher.TargetInRange,
            GameMatcher.AttackTimer,
            GameMatcher.AttackCooldown);
        _entities = contexts.game.GetGroup(matcher);
    }

    public void Execute()
    {
        foreach (var entity in _entities)
        {
            if (entity.attackTimer.Value <= 0)
            {
                entity.AddAttackRequest(null); // TODO
                entity.attackTimer.Value = entity.attackCooldown.Value;
            }
        }
    }
}