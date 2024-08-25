using Entitas;

public sealed class DamagedEventParticlesSystem : IExecuteSystem
{
	private readonly IGroup<GameEntity> _entities;
	private readonly DamagedParticlesHelper _damagedParticlesHelper;
	private EntityManager _entityManager;

	public DamagedEventParticlesSystem(Contexts contexts, DamagedParticlesHelper damagedParticlesHelper, EntityManager entityManager)
	{
		_damagedParticlesHelper = damagedParticlesHelper;
		_entityManager = entityManager;
		_damagedParticlesHelper.Initialize();

		var matcher = GameMatcher.AllOf(
			                         GameMatcher.DamagedEvent,
			                         GameMatcher.TransformView,
			                         GameMatcher.TypeId,
			                         GameMatcher.Health)
		                         .NoneOf(GameMatcher.Inactive);
		_entities = contexts.game.GetGroup(matcher);
	}

	public void Execute()
	{
		foreach (var entity in _entities)
		{
		}
	}
}