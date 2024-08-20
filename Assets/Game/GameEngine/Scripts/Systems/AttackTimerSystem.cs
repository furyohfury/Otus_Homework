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
        foreach (var entity in _entities.GetEntities())
        {
            if (entity.attackTimer.Value > 0)
            {
                entity.attackTimer.Value -= deltaTime;
            }    
        }
    }
}