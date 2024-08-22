using Entitas;

public class ArrowTriggerEnterRequestSystem : IExecuteSystem
{
	private readonly IGroup<GameEntity> _entities;
	private Contexts _contexts;

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
		foreach (var entity in _entities)
		{
			var target = entity.targetEntity;
			var damage = target.Value.damage;
			if (target.Value.isDamagableTag && !target.Value.isInactive)
			{
				var damageRequest = _contexts.game.CreateEntity();
				damageRequest.isTakeDamageRequest = true;
				damageRequest.AddTargetEntity(target.Value);
				damageRequest.AddDamage(damage.Value);
			}
			var source = entity.sourceEntity;
			source.Value.isInactive = true;
		}
	}
}