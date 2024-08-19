using Entitas;
using UnityEngine;

public sealed class TargetSearchSystem : IExecuteSystem
{
    private readonly IGroup<GameEntity> _searchGroup;
    private readonly IGroup<GameEntity> _targetGroup;

    public TargetSearchSystem(Contexts contexts)
    {
        var matcher = GameMatcher
            .AllOf(GameMatcher.Team, GameMatcher.AttackRange, GameMatcher.Position)
            .NoneOf(GameMatcher.EnemyTarget);
        _searchGroup = contexts.game.GetGroup(matcher);
        matcher = GameMatcher.AllOf(GameMatcher.Team, GameMatcher.Health);
        _targetGroup = contexts.game.GetGroup(matcher);
    }

    public void Execute()
    {
        foreach (var entity in _searchGroup.GetEntities())
        {
            var target = Vector3.zero;
            var minDistance = float.MaxValue;
            foreach (var ent in _targetGroup)
            {
                if (ent == entity || ent.team == entity.team) continue;

                var entPos = ent.position.Value;
                var distance = (entPos - entity.position.Value).sqrMagnitude;

                if (distance < minDistance)
                {
                    minDistance = distance;
                    target = entPos;
                }
            }

            if (target != Vector3.zero)
            {
                entity.AddTarget(target); // TODO cant modify collection
            }
        }
    }
}