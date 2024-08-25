using Entitas;

public sealed class TargetDeadSystem : IExecuteSystem
{
    private readonly IGroup<GameEntity> _entities;

    public TargetDeadSystem(Contexts contexts)
    {
        var matcher = GameMatcher.EnemyTarget;
        _entities = contexts.game.GetGroup(matcher);
    }

    public void Execute()
    {
        foreach (var entity in _entities.GetEntities())
        {
            if (entity.enemyTarget.Value.isEnabled && !entity.enemyTarget.Value.isInactive) continue;

            entity.RemoveEnemyTarget();
            entity.isTargetInRange = false;
            if (entity.hasMoveDirection)
            {
                entity.RemoveMoveDirection();
            }
        }
    }
}