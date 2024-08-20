﻿using Entitas;
using UnityEngine;

public sealed class MeleeAttackEventSystem : IExecuteSystem, ICleanupSystem
{
    private static readonly int MeleeAttack = Animator.StringToHash("MeleeAttack");
    private readonly IGroup<GameEntity> _entities;

    public MeleeAttackEventSystem(Contexts contexts)
    {
        var matcher = GameMatcher.AllOf(GameMatcher.AnimatorView, GameMatcher.MeleeAttackEvent);
        _entities = contexts.game.GetGroup(matcher);
    }

    public void Cleanup()
    {
        foreach (var entity in _entities.GetEntities())
        {
            entity.isMeleeAttackEvent = false;
        }
    }

    public void Execute()
    {
        foreach (var entity in _entities.GetEntities())
        {
            entity.animatorView.Value.SetTrigger(MeleeAttack);
        }
    }
}