using Entitas;

public class ArrowTriggerEnterRequestSystem : IExecuteSystem
{
	private readonly IGroup<GameEntity> _entities;
	private readonly Contexts _contexts;

	public ArrowTriggerEnterRequestSystem(Contexts contexts)
	{
		var matcher = GameMatcher.AllOf(
			GameMatcher.TriggerEnterRequest,
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
			if (source.typeId.Value != "Projectile") continue;
			
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
			entity.Destroy();
		}
	}
}