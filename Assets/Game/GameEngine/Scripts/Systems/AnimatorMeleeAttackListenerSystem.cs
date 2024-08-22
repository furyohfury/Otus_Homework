using Entitas;
using UnityEngine;

public sealed class AnimatorMeleeAttackListenerSystem : IExecuteSystem, ICleanupSystem
{
    private readonly IGroup<GameEntity> _entities;

    public AnimatorMeleeAttackListenerSystem(Contexts contexts)
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
            entity.animatorView.Value.SetTrigger(AnimatorHash.MeleeAttack);
        }
    }
}