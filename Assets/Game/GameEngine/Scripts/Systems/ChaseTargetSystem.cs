using Entitas;

public sealed class ChaseTargetSystem : IExecuteSystem
{
    private readonly IGroup<GameEntity> _chaseEntities;
    private readonly Contexts _contexts;

    public ChaseTargetSystem(Contexts contexts)
    {
        _contexts = contexts;
        var matcher = GameMatcher
            .AllOf(GameMatcher.Target, GameMatcher.AttackRange);
        _chaseEntities = contexts.game.GetGroup(matcher);
    }

    public void Execute()
    {
        foreach (var entity in _chaseEntities)
        {
            var distanceVector = entity.target.Value - entity.position.Value;
            if (distanceVector.sqrMagnitude > entity.attackRange.Value * entity.attackRange.Value)
            {
                if (entity.hasMoveDirection)
                {
                    entity.ReplaceMoveDirection(distanceVector);
                }
                else
                {
                    entity.AddMoveDirection(distanceVector);
                }
            }
            else
            {
                entity.RemoveMoveDirection();
                var attackRequestEntity = _contexts.game.CreateEntity();
                attackRequestEntity.AddAttackRequest(entity);
            }
        }
    }
}