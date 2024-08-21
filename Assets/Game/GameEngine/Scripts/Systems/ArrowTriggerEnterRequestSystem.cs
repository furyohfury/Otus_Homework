using Entitas;

public class ArrowTriggerEnterRequestSystem : IExecuteSystem
{
	private readonly IGroup<GameEntity> _requests;
	private Contexts _contexts;

	public ArrowTriggerEnterRequestSystem(Contexts contexts)
	{
		var matcher = GameMatcher.AllOf(
			GameMatcher.TriggerEnterRequest,
			GameMatcher.ArrowTag,
			GameMatcher.SourceEntity,
			GameMatcher.TargetEntity);
		_requests = contexts.game.GetGroup(matcher);

		_contexts = contexts;
	}


	public void Execute()
	{
		foreach (var request in _requests)
		{
			var target = request.targetEntity;
			var damage = target.Value.damage;
			if (target.Value.isDamagableTag)
			{
				var damageRequest = _contexts.game.CreateEntity();
				damageRequest.isTakeDamageRequest = true;
				damageRequest.AddTargetEntity(target.Value);
				damageRequest.AddDamage(damage.Value);
			}
			var source = request.sourceEntity; // todo tag to destroy arrow
		}
	}
}