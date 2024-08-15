using Entitas;

public class RenderPositionSystem : IExecuteSystem
{
    private readonly IGroup<GameEntity> _group;

    public RenderPositionSystem(Contexts contexts)
    {
        var matcher = GameMatcher.AllOf(GameMatcher.TransformView, GameMatcher.Position);
        _group = contexts.game.GetGroup(matcher);
    }

    public void Execute()
    {
        foreach (GameEntity e in _group)
        {
            e.transformView.Value.position = e.position.Value;
        }
    }
}