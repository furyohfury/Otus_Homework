using Entitas;
using Entitas.Unity;
using UnityEngine;

public class AddViewSystem : IExecuteSystem
{
    private readonly Transform _viewContainer = new GameObject("Game Views").transform;
    private readonly IGroup<GameEntity> _viewGroup;

    public AddViewSystem(Contexts contexts)
    {
        _viewGroup = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Position,
                                                              GameMatcher.SpawnRequest));
    }

    public void Execute()
    {
        foreach (var ent in _viewGroup)
        {
            var go = new GameObject("Game View");
            go.transform.SetParent(_viewContainer, false);
            ent.AddTransformView(go.transform);
            ent.ReplacePosition(Vector3.zero);
            go.Link(ent);

            ent.isSpawnRequest = false;
        }
    }
}