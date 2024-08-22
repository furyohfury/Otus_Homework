using Entitas;

public sealed class ShootRequestSystem : IExecuteSystem, ICleanupSystem
{
	private readonly IGroup<GameEntity> _entities;
	private readonly Contexts _contexts;

	public ShootRequestSystem(Contexts contexts)
	{
		var matcher = GameMatcher.AllOf(GameMatcher.ShootRequest, GameMatcher.RangeWeapon);
		_entities = contexts.game.GetGroup(matcher);

		_contexts = contexts;
	}

	public void Execute()
	{
		foreach (var entity in _entities.GetEntities())
		{
			var weapon = entity.rangeWeapon;

			var spawnEvent = _contexts.game.CreateEntity();
			spawnEvent.isSpawnRequest = true;
			spawnEvent.AddPosition(weapon.FirePoint.position);
			spawnEvent.AddDirection(weapon.FirePoint.rotation);
			spawnEvent.AddPrefab(weapon.ProjectilePrefab);
		}
	}

	public void Cleanup()
	{
		foreach (var entity in _entities.GetEntities())
		{
			entity.isShootRequest = false;
		}
	}
}