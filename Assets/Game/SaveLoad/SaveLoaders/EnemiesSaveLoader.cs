using System.Collections.Generic;
using System.Linq;
using Atomic.Entities;
using Game;
using UnityEngine;

namespace SaveLoad
{
	public sealed class EnemiesSaveLoader : SaveLoader<EnemyData[], EnemyService>
	{
		private readonly Dictionary<string, SceneEntity> _prefabs;

		public EnemiesSaveLoader(Dictionary<string, SceneEntity> prefabs)
		{
			_prefabs = prefabs;
		}

		protected override EnemyData[] ConvertToData(EnemyService service)
		{
			var enemies = service.GetEnemies(true);
			var saveData = new EnemyData[enemies.Count];
			int index = 0;
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
				saveData[index++] = enemyData;
			}

			return saveData;
		}

		protected override void SetupData(EnemyService service, EnemyData[] data)
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
			EnableEnemy(sceneEnemy);
		}

		private static void EnableEnemy(IEntity sceneEnemy)
		{
			SpriteRenderer[] spriteRenderers = sceneEnemy.GetSpriteRenderers();
			for (int i = 0, count = spriteRenderers.Length; i < count; i++)
			{
				spriteRenderers[i].enabled = true;
			}

			sceneEnemy.GetAnimator().CrossFade("idle", 0);
			sceneEnemy.GetMoveDirection().Value = Vector2.zero;
			sceneEnemy.GetRigidbody2D().simulated = true;
			var glowRedOnTakeDamageBehaviour = sceneEnemy.GetBehaviour<GlowRedOnTakeDamageBehaviour>();
			glowRedOnTakeDamageBehaviour.RestoreColors();
		}
	}
}