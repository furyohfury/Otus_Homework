using Entitas;

public class TakeDamageRequestSystem : IExecuteSystem, ICleanupSystem
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
				var targetHp = target.health.Value;
				targetHp -= entity.damage.Value;
			}
			// TODO takedamage event and system for visual
			target.isDamagedEvent = true;
			entity.Destroy();
		}
	}
	
	public void Cleanup()
	{
		foreach (var entity in _entities.GetEntities())
		{			
			target.isDamagedEvent = false;
		}
	}
}