using System.Collections.Generic;
using System.Linq;
using Atomic.Entities;
using Game;
using UnityEngine;

namespace SaveLoad
{
	public sealed class EnemiesSaveLoader : SaveLoader<IEnumerable<EnemyData>, EnemyService>
	{
		private readonly Dictionary<string, SceneEntity> _prefabs;

		public EnemiesSaveLoader(Dictionary<string, SceneEntity> prefabs)
		{
			_prefabs = prefabs;
		}

		protected override IEnumerable<EnemyData> ConvertToData(EnemyService service)
		{
			var enemies = service.Enemies;
			var saveData = new List<EnemyData>();
			foreach (var enemy in enemies)
			{
				Transform enemyTransform = enemy.GetVisualTransform();
				string enemyId = enemy.GetId();
				var instanceId = enemy.InstanceId;
				var enemyHealth = enemy.GetHealth().Value;

				var enemyData = new EnemyData(
					instanceId,
					enemyId,
					enemyTransform.position,
					enemyTransform.rotation,
					enemyHealth);

				saveData.Add(enemyData);
			}

			return saveData;
		}

		protected override void SetupData(EnemyService service, IEnumerable<EnemyData> data)
		{
			var sceneEnemies = service.Enemies;
			if (sceneEnemies == null)
			{
				return;
			}

			var world = Object.FindObjectOfType<SceneEntityWorld>();
			var worldTransform = world.transform;
			IEnumerable<EnemyData> enemyDatas = data.ToList();

			foreach (var sceneEnemy in sceneEnemies)
			{
				if (enemyDatas.Any(enemyData => enemyData.InstanceId == sceneEnemy.InstanceId) == false)
				{
					SceneEntity.Destroy(sceneEnemy);
				}
			}

			foreach (var enemyData in enemyDatas)
			{
				var sceneEnemy = sceneEnemies.SingleOrDefault(sceneEnemy => sceneEnemy.InstanceId == enemyData.InstanceId);
				if (sceneEnemy != default)
				{
					SetupExistingEnemy(sceneEnemy, enemyData);
				}
				else
				{
					CreateNewEnemy(enemyData, worldTransform);
				}
			}
		}

		private static void SetupExistingEnemy(IEntity sceneEnemy, EnemyData enemyData)
		{
			var enemyTransform = sceneEnemy.GetVisualTransform();
			enemyTransform.SetPositionAndRotation(enemyData.Position, enemyData.Rotation);
			sceneEnemy.GetHealth().Value = enemyData.Health;
		}

		private void CreateNewEnemy(EnemyData enemyData, Transform worldTransform)
		{
			var id = enemyData.Id;
			var prefab = _prefabs[id];
			var pos = enemyData.Position;
			var rot = enemyData.Rotation;
			var newEnemy = SceneEntity.Instantiate(prefab, pos, rot, worldTransform);
			newEnemy.GetHealth().Value = enemyData.Health;
		}
	}
}