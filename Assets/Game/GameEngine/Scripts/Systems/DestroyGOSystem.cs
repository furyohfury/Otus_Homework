using Entitas;

public class DestroyGOSystem : IExecuteSystem
{
	private readonly IGroup<GameEntity> _entities;

	public DestroyGOSystem(Contexts contexts)
	{
		var matcher = GameMatcher.AllOf(GameMatcher.Inactive);
		_entities = contexts.game.GetGroup(matcher);
	}

	public void Execute()
	{
		foreach (var entity in _entities)
		{
			var animator = entity.animatorView.Value;
            animator.SetTrigger("Death");
		}
	}
}