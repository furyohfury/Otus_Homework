using Entitas;
using UnityEngine;

public sealed class TargetSearchSystem : IExecuteSystem
{
    private readonly IGroup<GameEntity> _searchGroup;

    public TargetSearchSystem(Contexts contexts)
    {
        var matcher = GameMatcher
            .AllOf(GameMatcher.Team, GameMatcher.AttackRange, GameMatcher.TransformView)
            .NoneOf(GameMatcher.EnemyTarget);
        _searchGroup = contexts.game.GetGroup(matcher);
    }

    public void Execute()
    {
        foreach (var entity in _searchGroup)
        {
            Transform target = null;
            var minDistance = float.MaxValue;
            foreach (var ent in _searchGroup)
            {
                if (ent == entity || ent.team == entity.team) continue;

                var entPos = ent.position.Value;
                var distance = (entPos - entity.position.Value).sqrMagnitude;

                if (distance < minDistance)
                {
                    minDistance = distance;
                    target = ent.transformView.Value;
                }
            }

            if (target != null)
            {
                entity.AddEnemyTarget(target); // TODO cant modify collection
            }
        }
    }
}