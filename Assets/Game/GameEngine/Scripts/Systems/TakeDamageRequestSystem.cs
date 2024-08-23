using Entitas;

public class TakeDamageRequestSystem : IExecuteSystem
{
	private readonly IGroup<GameEntity> _entities;

	public TakeDamageRequestSystem(Contexts contexts)
	{
		var matcher = GameMatcher.AllOf(
			GameMatcher.TakeDamageRequest,
			GameMatcher.Damage,
			GameMatcher.TargetEntity);
		_entities = contexts.game.GetGroup(matcher);
	}

	public void Execute()
	{
		foreach (var entity in _entities.GetEntities())
		{
			var target = entity.targetEntity.Value;
			if (target.hasHealth)
			{
				var targetHp = target.health;
				targetHp.Current -= entity.damage.Value;
			}

			target.isDamagedEvent = true;
			entity.Destroy();
		}
	}
}