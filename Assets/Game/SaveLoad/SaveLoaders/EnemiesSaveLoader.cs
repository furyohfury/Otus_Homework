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
			var enemies = service.GetEnemies(true);
			var saveData = new List<EnemyData>(enemies.Count);
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
			IReadOnlyCollection<IEntity> sceneEnemies = service.GetEnemies(true);
			if (sceneEnemies == null || sceneEnemies.Count <= 0)
			{
				return;
			}

			var dict = sceneEnemies.ToDictionary(enemy => enemy.InstanceId);

			foreach (EnemyData enemyData in data)
			{
				var sceneEnemy = dict[enemyData.InstanceId];
				SceneEntity sceneEntity = SceneEntity.Cast(sceneEnemy);
				sceneEntity.gameObject.SetActive(true);
				SetupExistingEnemy(sceneEnemy, enemyData);
			}
		}

		private static void SetupExistingEnemy(IEntity sceneEnemy, EnemyData enemyData)
		{
			var enemyTransform = sceneEnemy.GetVisualTransform();
			enemyTransform.SetPositionAndRotation(enemyData.Position, enemyData.Rotation);
			sceneEnemy.GetHealth().Value = enemyData.Health;
		}
	}
}