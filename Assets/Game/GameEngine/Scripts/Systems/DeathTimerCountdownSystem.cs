using Entitas;

public sealed class DeathTimerCountdownSystem : IExecuteSystem
{
	private readonly IGroup<GameEntity> _entities;

	public DeathTimerCountdownSystem(Contexts contexts)
	{
		var matcher = GameMatcher.DeathTimer;
		_entities = contexts.game.GetGroup(matcher);
	}

	public void Execute()
	{
		foreach (var entity in _entities.GetEntities())
		{
			var deltaTime = UnityEngine.Time.deltaTime;
			var timer = entity.deathTimer;
			if (timer.Value <= 0)
			{
				entity.isDeathRequest = true;
				entity.RemoveDeathTimer();
			}
			else
			{
				timer.Value -= deltaTime;
			}
		}
	}
}