using DG.Tweening;
using Entitas;

public sealed class BuildingDeathEventSystem : IExecuteSystem
{
	private readonly IGroup<GameEntity> _entities;

	public BuildingDeathEventSystem(Contexts contexts)
	{
		var matcher = GameMatcher.AllOf(GameMatcher.TypeId, GameMatcher.DeathEvent)
		                         .NoneOf(GameMatcher.DelayedDeath);
		_entities = contexts.game.GetGroup(matcher);
	}

	public void Execute()
	{
		foreach (var entity in _entities.GetEntities())
		{
			if (entity.typeId.Value == "Building")
			{
				entity.isDelayedDeath = true;
			}

			DOVirtual.DelayedCall(3, () => entity.isDelayedDeath = false);
		}
	}
}