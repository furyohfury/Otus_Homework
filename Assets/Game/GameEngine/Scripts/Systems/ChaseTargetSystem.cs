using Entitas;

public sealed class ChaseTargetSystem : IExecuteSystem
{
    private readonly IGroup<GameEntity> _entities;

    public ChaseTargetSystem(Contexts contexts)
    {
        var matcher = GameMatcher
            .AllOf(GameMatcher.EnemyTarget, GameMatcher.AttackRange);
        _entities = contexts.game.GetGroup(matcher);
    }

    public void Execute()
    {
        foreach (var entity in _entities.GetEntities())
        {
            var enemy = entity.enemyTarget.Value;
            var vectorToTarget = enemy.position.Value - entity.position.Value;
            if (vectorToTarget.sqrMagnitude > entity.attackRange.Value * entity.attackRange.Value)
            {
                entity.ReplaceMoveDirection(vectorToTarget);
                entity.isTargetInRange = false;
            }
            else if (entity.hasMoveDirection)
            {
                entity.RemoveMoveDirection();
                entity.isTargetInRange = true;
            }
        }
    }
}