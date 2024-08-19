using Entitas;

public sealed class TargetDeadSystem : IExecuteSystem
{
    private readonly IGroup<GameEntity> _entities;

    public TargetDeadSystem(Contexts contexts)
    {
        _entities = contexts.game.GetGroup(GameMatcher.Target);
    }

    public void Execute()
    {
        foreach (var entity in _entities)
        {
            if (entity.enemyTarget.Value == null)
            {
                entity.RemoveTarget();
            }
        }
    }
}