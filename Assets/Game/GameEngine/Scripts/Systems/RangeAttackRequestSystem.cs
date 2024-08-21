using Entitas;

public sealed class RangeAttackRequestSystem : IExecuteSystem, ICleanupSystem
{
    private readonly IGroup<GameEntity> _entities;
    private readonly Contexts _contexts;

    public RangeAttackRequestSystem(Contexts contexts)
    {
        var matcher = GameMatcher.AllOf(GameMatcher.AttackRequest, GameMatcher.RangeAttacker, GameMatcher.RangeWeapon);
        _entities = contexts.game.GetGroup(matcher);

        _contexts = contexts;
    }    

    public void Execute()
    {
        foreach (var entity in _entities.GetEntities())
        {
            entity.isRangeAttackEvent = true;

            var weapon = entity.rangeWeapon.Value;

            var spawnEvent = _contexts.game.CreateEntity();
            spawnEvent.AddPosition(weapon.FirePoint.Value.position);
            spawnEvent.AddDirection(weapon.FirePoint.Value.rotation);
            spawnEvent.AddPrefab(weapon.ProjectilePrefab.Value);
        }
    }

    public void Cleanup()
    {
        foreach (var entity in _entities.GetEntities())
        {
            entity.RemoveAttackRequest();
        }
    }
}