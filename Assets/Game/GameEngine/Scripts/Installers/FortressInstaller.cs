using UnityEngine;
using System.Linq;

public class FortressInstaller : EntityInstaller
{
	[SerializeField]
	private int _health;
	[SerializeField]
	private Team _team;
	[SerializeField]
	private Transform _spawnContainer;
	[SerializeField]
	private Transform _spawnPointsContainer;
	public EntityView[] UnitsToSpawn;

	private Transform[] _spawnPoints;
	
	public override void Install(GameEntity entity)
	{
		entity.AddPosition(transform.position);
		entity.AddRotation(transform.rotation);
		entity.AddHealth(_health, _health);
		entity.isDamagableTag = true;
		entity.AddTeam(_team);
		entity.AddTypeId("Building");
		entity.AddTransformView(transform);
		
		var gameContext = Contexts.sharedInstance.game;
		_spawnPoints = _spawnPointsContainer.GetComponentsInChildren<Transform>().Skip(1).ToArray();
		foreach (var entityView in UnitsToSpawn)
		{
			var spawnRequest = gameContext.CreateEntity();
			spawnRequest.isSpawnRequest = true;
			var index = Random.Range(0, _spawnPoints.Length - 1);
			var spawnPoint = _spawnPoints[index];
			spawnRequest.AddPosition(spawnPoint.position);
			spawnRequest.AddPrefab(entityView);
			spawnRequest.AddRotation(transform.rotation);
			spawnRequest.AddTransformView(_spawnContainer);
		}
	}

	public override void Dispose(GameEntity entity)
	{
	}
}