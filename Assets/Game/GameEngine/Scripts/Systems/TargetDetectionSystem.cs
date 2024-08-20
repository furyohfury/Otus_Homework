using Entitas;
using UnityEngine;

public sealed class TargetDetectionSystem : IExecuteSystem
{
    private readonly IGroup<GameEntity> _searchGroup;
    private readonly IGroup<GameEntity> _targetGroup;

    public TargetDetectionSystem(Contexts contexts)
    {
        var matcher = GameMatcher
            .AllOf(GameMatcher.Team, GameMatcher.AttackRange, GameMatcher.Position)
            .NoneOf(GameMatcher.EnemyTarget);
        _searchGroup = contexts.game.GetGroup(matcher);
        matcher = GameMatcher.AllOf(GameMatcher.Team, GameMatcher.Health,GameMatcher.Position);
        _targetGroup = contexts.game.GetGroup(matcher);
    }

    public void Execute()
    {
        foreach (var entity in _searchGroup.GetEntities())
        {
            GameEntity target = null;
            var minDistance = float.MaxValue;
            foreach (var ent in _targetGroup)
            {
                if (ent == entity || ent.team == entity.team) continue;

                var entPos = ent.position.Value;
                var distance = (entPos - entity.position.Value).sqrMagnitude;

                if (distance < minDistance)
                {
                    minDistance = distance;
                    target = ent;
                }
            }

            if (target != null)
            {
                entity.AddEnemyTarget(target);
            }
        }
    }
}