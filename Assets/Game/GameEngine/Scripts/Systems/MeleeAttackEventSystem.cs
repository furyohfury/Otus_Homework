using Entitas;
using UnityEngine;

public sealed class MeleeAttackEventSystem : IExecuteSystem, ICleanupSystem
{
    private IGroup<GameEntity> _entities;
    private static readonly int MeleeAttack = Animator.StringToHash("MeleeAttack");

    public MeleeAttackEventSystem(Contexts contexts)
    {
        var matcher = GameMatcher.AllOf(GameMatcher.AnimatorView, GameMatcher.MeleeAttackEvent);
        _entities = contexts.game.GetGroup(matcher);
    }

    public void Execute()
    {
        foreach (var entity in _entities.GetEntities())
        {
            entity.animatorView.Value.SetTrigger(MeleeAttack);
        }
    }

    public void Cleanup()
    {
        foreach (var entity in _entities.GetEntities())
        {
            entity.isMeleeAttackEvent = false;
        }
    }
}