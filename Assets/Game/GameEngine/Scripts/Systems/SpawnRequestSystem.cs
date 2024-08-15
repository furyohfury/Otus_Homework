using Entitas;
using UnityEngine;

public sealed class SpawnRequestSystem : IExecuteSystem
{
    private readonly IGroup<GameEntity> _viewGroup;

    public SpawnRequestSystem(Contexts contexts)
    {
        _viewGroup = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Position).NoneOf(GameMatcher.TransformView));
    }

    public void Execute()
    {
        foreach (var entity in _viewGroup)
        {
            entity.isSpawnRequest = true;
        }
    }
}