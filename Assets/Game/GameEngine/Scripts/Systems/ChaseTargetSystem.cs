using Entitas;

public sealed class ChaseTargetSystem : IExecuteSystem
{
    private readonly IGroup<GameEntity> _chaseEntities;
    private Contexts _contexts;

    public ChaseTargetSystem(Contexts contexts)
    {
        _contexts = contexts;
        var matcher = GameMatcher
            .AllOf(GameMatcher.EnemyTarget, GameMatcher.AttackRange);
        _chaseEntities = contexts.game.GetGroup(matcher);
    }

    public void Execute()
    {
        foreach (var entity in _chaseEntities)
        {
            if ((entity.enemyTarget.Value.position - entity.position.Value).sqrMagnitude > entity.attackRange.Value)
            {
                if (entity.hasMoveDirection)
                {
                    entity.ReplaceMoveDirection(entity.enemyTarget.Value.position);
                }
            }
            else
            {
                var attackRequestEntity = _contexts.game.CreateEntity();
                attackRequestEntity.AddAttackRequest(entity);
            }
        }
    }
}