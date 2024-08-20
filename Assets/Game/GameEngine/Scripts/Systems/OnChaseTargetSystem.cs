using Entitas;

public sealed class OnChaseTargetSystem : IExecuteSystem //TODO RENAME
{
    private readonly IGroup<GameEntity> _entities;
    private readonly Contexts _contexts;

    public OnChaseTargetSystem(Contexts contexts)
    {
        _contexts = contexts;
        var matcher = GameMatcher
            .AllOf(GameMatcher.Target, GameMatcher.MoveDirection, GameMatcher.AttackRange);
        _entities = contexts.game.GetGroup(matcher);
    }

    public void Execute()
    {
        foreach (var entity in _entities)
        {
            var distanceVector = entity.target.Value - entity.position.Value;
            if (distanceVector.sqrMagnitude > entity.attackRange.Value * entity.attackRange.Value)
            {
                entity.ReplaceMoveDirection(distanceVector);                
            }
            else
            {
                entity.RemoveMoveDirection();
            }
        }
    }
}