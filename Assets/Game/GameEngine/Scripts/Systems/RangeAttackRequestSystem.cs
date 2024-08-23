using Entitas;

public sealed class RangeAttackRequestSystem : IExecuteSystem, ICleanupSystem
{
	private readonly IGroup<GameEntity> _entities;
    
	public RangeAttackRequestSystem(Contexts contexts)
	{
		var matcher = GameMatcher.AllOf(GameMatcher.AttackRequest, GameMatcher.RangeAttacker);
		_entities = contexts.game.GetGroup(matcher);
	}    
	public void Execute()
	{
		foreach (var entity in _entities.GetEntities())
		{
			entity.isRangeAttackEvent = true;
			entity.isAttackRequest = false;
		}
	}

	public void Cleanup()
	{
		foreach (var entity in _entities.GetEntities())
		{
			entity.isRangeAttackEvent = false;
		}
	}
}