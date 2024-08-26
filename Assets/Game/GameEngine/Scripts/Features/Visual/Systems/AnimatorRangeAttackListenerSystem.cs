using Entitas;

public sealed class AnimatorRangeAttackListenerSystem : IExecuteSystem
{
	private readonly IGroup<GameEntity> _entities;

	public AnimatorRangeAttackListenerSystem(Contexts contexts)
	{
		var matcher = GameMatcher.AllOf(GameMatcher.RangeAttackEvent, GameMatcher.AnimatorView)
		                         .NoneOf(GameMatcher.Inactive, GameMatcher.DeathRequest);
		_entities = contexts.game.GetGroup(matcher);
	}

	public void Execute()
	{
		foreach (var entity in _entities.GetEntities())
		{
			entity.animatorView.Value.SetTrigger(AnimatorHash.RangeAttack);
		}
	}
}