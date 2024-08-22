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
		foreach (var entity in _entities)
		{
			entity.isRangeAttackEvent = true;
		}
	}

	public void Cleanup()
	{
		foreach (var entity in _entities)
		{
			entity.isRangeAttackEvent = false;
		}
	}
}