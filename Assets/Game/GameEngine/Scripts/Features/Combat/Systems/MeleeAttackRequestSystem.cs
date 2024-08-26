using Entitas;

public sealed class MeleeAttackRequestSystem : IExecuteSystem
{
	private readonly IGroup<GameEntity> _entities;

	public MeleeAttackRequestSystem(Contexts contexts)
	{
		var matcher = GameMatcher.AllOf(GameMatcher.AttackRequest, GameMatcher.MeleeAttacker);
		_entities = contexts.game.GetGroup(matcher);
	}

	public void Execute()
	{
		foreach (var entity in _entities.GetEntities())
		{
			entity.isMeleeAttackEvent = true;
			entity.isAttackRequest = false;
		}
	}
}