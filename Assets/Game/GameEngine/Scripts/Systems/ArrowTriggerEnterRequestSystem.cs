using Entitas;

public class ArrowTriggerEnterRequestSystem : IExecuteSystem, ICleanupSystem
{
	private readonly IGroup<GameEntity> _entities;
	private readonly Contexts _contexts;

	public ArrowTriggerEnterRequestSystem(Contexts contexts)
	{
		var matcher = GameMatcher.AllOf(
			GameMatcher.TriggerEnterRequest,
			GameMatcher.ArrowTag,
			GameMatcher.SourceEntity,
			GameMatcher.TargetEntity);
		_entities = contexts.game.GetGroup(matcher);

		_contexts = contexts;
	}

	public void Execute()
	{
		foreach (var entity in _entities.GetEntities())
		{
			var source = entity.sourceEntity.Value;
			var target = entity.targetEntity.Value;
			if (target.isDamagableTag && !target.isInactive)
			{
				var damage = source.damage.Value;

				var damageRequest = _contexts.game.CreateEntity();
				damageRequest.isTakeDamageRequest = true;
				damageRequest.AddTargetEntity(target);
				damageRequest.AddDamage(damage);
			}

			source.isInactive = true;
		}
	}

	public void Cleanup()
	{
		foreach (var entity in _entities.GetEntities())
		{
			entity.Destroy();
		}
	}
}