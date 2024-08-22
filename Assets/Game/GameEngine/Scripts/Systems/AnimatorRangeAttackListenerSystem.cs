using Entitas;

public sealed class AnimatorRangeAttackListenerSystem : IExecuteSystem, ICleanupSystem
{
    private readonly IGroup<GameEntity> _entities;

    public AnimatorRangeAttackListenerSystem(Contexts contexts)
    {
        var matcher = GameMatcher.AllOf(GameMatcher.RangeAttackEvent, GameMatcher.AnimatorView);
        _entities = contexts.game.GetGroup(matcher);
    }    

    public void Execute()
    {
        foreach (var entity in _entities.GetEntities())
        {
            entity.animatorView.Value.SetTrigger(AnimatorHash.RangeAttack);            
        }
    }

    public void Cleanup()
    {
        foreach (var entity in _entities.GetEntities())
        {
            entity.isRangeAttackEvent = false;
        }
    }
}