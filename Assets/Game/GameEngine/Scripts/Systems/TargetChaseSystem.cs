using Entitas;

public sealed class TargetChaseSystem : IExecuteSystem
{
    private readonly IGroup<GameEntity> _entities;

    public TargetChaseSystem(Contexts contexts)
    {
        var matcher = GameMatcher
            .AllOf(GameMatcher.EnemyTarget, GameMatcher.AttackRange)
            .NoneOf(GameMatcher.Inactive);
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
                if (entity.hasMoveDirection)
                {
                    entity.moveDirection.Value = vectorToTarget;
                }
                else
                {
                    entity.AddMoveDirection(vectorToTarget);
                }
                entity.isTargetInRange = false;
                continue;
            }
            
            if (entity.hasMoveDirection)
            {
                entity.RemoveMoveDirection();
            }
            entity.isTargetInRange = true;
        }
    }
}