using Entitas;

public sealed class ChaseTargetSystem : IExecuteSystem
{
    private readonly IGroup<GameEntity> _entities;
    private readonly Contexts _contexts;

    public ChaseTargetSystem(Contexts contexts)
    {
        _contexts = contexts;
        var matcher = GameMatcher
            .AllOf(GameMatcher.Target, GameMatcher.AttackRange)
            .NoneOf(GameMatcher.MoveDirection);
        _entities = contexts.game.GetGroup(matcher);
    }

    public void Execute()
    {
        foreach (var entity in _entities)
        {
            var distanceVector = entity.target.Value - entity.position.Value;
            if (distanceVector.sqrMagnitude > entity.attackRange.Value * entity.attackRange.Value)
            {
                entity.AddMoveDirection(distanceVector);                
            }
        }
    }
}