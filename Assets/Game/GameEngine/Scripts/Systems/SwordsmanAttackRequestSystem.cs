﻿using Entitas;

public sealed class SwordsmanAttackRequestSystem : IExecuteSystem, ICleanupSystem
{
    private IGroup<GameEntity> _entities;

    public SwordsmanAttackRequestSystem(Contexts contexts)
    {
        var matcher = GameMatcher.AllOf(GameMatcher.AttackRequest); // TODO make swordsman component?
        _entities = contexts.game.GetGroup(matcher);
    }

    public void Execute()
    {
        foreach (var entity in _entities.GetEntities())
        {
            entity.isMeleeAttackEvent = true;
        }
    }

    public void Cleanup()
    {
        foreach (var entity in _entities.GetEntities())
        {
            entity.isAttackRequest = false;
        }
    }
}