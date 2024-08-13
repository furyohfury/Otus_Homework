using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class DebugMessageSystem : IExecuteSystem
{
    private readonly IGroup<GameEntity> _group;
    public DebugMessageSystem(Contexts contexts)
    {
        _group = contexts.game.GetGroup(GameMatcher.DebugMessage);
    }

    void IExecuteSystem.Execute()
    {
        foreach (var entity in _group)
        {
            Debug.Log(entity.debugMessage.message);
        }
    }
}