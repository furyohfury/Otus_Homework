using Entitas;

public sealed class AnimatorMeleeAttackListenerSystem : IExecuteSystem
{
	private readonly IGroup<GameEntity> _entities;

	public AnimatorMeleeAttackListenerSystem(Contexts contexts)
	{
		var matcher = GameMatcher.AllOf(GameMatcher.AnimatorView, GameMatcher.MeleeAttackEvent)
		                         .NoneOf(GameMatcher.Inactive, GameMatcher.DeathRequest);
		_entities = contexts.game.GetGroup(matcher);
	}

	public void Execute()
	{
		foreach (var entity in _entities.GetEntities())
		{
			entity.animatorView.Value.SetTrigger(AnimatorHash.MeleeAttack);
		}
	}
}