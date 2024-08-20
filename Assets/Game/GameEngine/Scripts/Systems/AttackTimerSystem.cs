using Entitas;

public sealed class AttackTimerSystem : IExecuteSystem
{
    private readonly IGroup<GameEntity> _entities;

    public AttackTimerSystem(Contexts contexts)
    {
        var matcher = GameMatcher.AttackTimer; // TODO add attackcdcomponent
        _entities = contexts.game.GetGroup(matcher);
    }

    public void Execute()
    {
        var deltaTime = UnityEngine.Time.deltaTime;
        foreach (var entity in _entities)
        {
            if (entity.AttackTimer.Value > 0)
            {
                entity.AttackTimer.Value -= deltaTime;
            }    
        }
    }
}