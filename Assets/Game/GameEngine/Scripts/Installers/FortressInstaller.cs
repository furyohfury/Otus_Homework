using UnityEngine;

public class FortressInstaller : EntityInstaller
{
	[SerializeField]
	private int _health;
	[SerializeField]
	private Team _team;
	[SerializeField]
	private EntityView[] _unitsToSpawn;
	[SerializeField]
	private Transform _spawnContainer;
	[SerializeField]
	private Transform _spawnPointsContainer;
	private Transform[] _spawnPoints;

	public override void Install(GameEntity entity)
	{
		entity.AddHealth(_health, _health);
		entity.isDamagableTag = true;
		entity.AddTeam(_team);
		entity.AddPosition(transform.position);
		entity.AddDirection(transform.rotation);
		entity.AddTypeId("Building");
		entity.AddTransformView(transform);
		var gameContext = Contexts.sharedInstance.game;
		_spawnPoints = _spawnPointsContainer.GetComponentsInChildren<Transform>();
		foreach (var entityView in _unitsToSpawn)
		{
			var spawnRequest = gameContext.CreateEntity();
			spawnRequest.isSpawnRequest = true;
			var index = Random.Range(0, _spawnPoints.Length - 1);
			var spawnPoint = _spawnPoints[index];
			spawnRequest.AddPosition(spawnPoint.position);
			spawnRequest.AddPrefab(entityView);
			spawnRequest.AddDirection(transform.rotation);
			spawnRequest.AddTransformView(_spawnContainer);
		}
	}

	public override void Dispose(GameEntity entity)
	{
	}
}