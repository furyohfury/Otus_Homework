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
		foreach (var entity in _entities)
		{
			var target = entity.targetEntity;
			if (target.Value.hasHealth)
			{
				var targetHp = target.Value.health;
				targetHp.Value -= entity.damage.Value;
			}
			// TODO takedamage event and system for visual
		}
	}
	
	public void Cleanup()
	{
		foreach (var entity in _entities)
		{
			entity.Destroy();
		}
	}
}