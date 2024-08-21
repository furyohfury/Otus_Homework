using Entitas;

public sealed class SwordsmanAttackRequestSystem : IExecuteSystem, ICleanupSystem
{
    private readonly IGroup<GameEntity> _entities;

    public SwordsmanAttackRequestSystem(Contexts contexts)
    {
        var matcher = GameMatcher.AllOf(GameMatcher.AttackRequest, GameMatcher.isMeleeAttacker);
        _entities = contexts.game.GetGroup(matcher);
    }

    public void Cleanup()
    {
        foreach (var entity in _entities.GetEntities())
        {
            entity.isAttackRequest = false;
        }
    }

    public void Execute()
    {
        foreach (var entity in _entities.GetEntities())
        {
            entity.isMeleeAttackEvent = true;
        }
    }
}