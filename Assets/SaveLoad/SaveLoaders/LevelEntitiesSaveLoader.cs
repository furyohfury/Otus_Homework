using System.Collections.Generic;
using System.Linq;
using Atomic.Entities;
using Game;
using UnityEngine;

namespace SaveLoad
{
	public sealed class LevelEntitiesSaveLoader : SaveLoader<IEnumerable<LevelEntityData>, LevelEntitiesService>
	{
		private readonly Dictionary<string, SceneEntity> _prefabs;

		public LevelEntitiesSaveLoader(Dictionary<string, SceneEntity> prefabs)
		{
			_prefabs = prefabs;
		}

		protected override IEnumerable<LevelEntityData> ConvertToData(LevelEntitiesService service)
		{
			IReadOnlyList<IEntity> entities = service.GetLevelEntities();
			LevelEntityData[] data = new LevelEntityData[entities.Count];
			for (int i = 0, count = data.Length; i < count; i++)
			{
				var id = entities[i].GetId();
				var instanceId = entities[i].InstanceId;
				var entityTransform = entities[i].GetVisualTransform();
				data[i] = new LevelEntityData(
					id,
					instanceId,
					entityTransform.position,
					entityTransform.rotation,
					entityTransform.localScale);
			}

			return data;
		}

		protected override void SetupData(LevelEntitiesService service, IEnumerable<LevelEntityData> data)
		{
			var sceneEntities = service.GetLevelEntities();
			IEnumerable<LevelEntityData> levelEntityDatas = data.ToArray();

			foreach (var sceneEntity in sceneEntities)
			{
				if (levelEntityDatas.Any(entityData => entityData.InstanceId == sceneEntity.InstanceId) == false)
				{
					DestroyEntity(sceneEntity);
				}
			}

			foreach (var entityData in levelEntityDatas)
			{
				var sceneEntity = sceneEntities.SingleOrDefault(sceneEnemy => sceneEnemy.InstanceId == entityData.InstanceId);
				if (sceneEntity == default)
				{
					CreateNewEntity(entityData, service.Container);
				}
				else
				{
					SetupExistingEntity(sceneEntity, entityData);
				}
			}
		}

		private static void DestroyEntity(IEntity sceneEntity)
		{
			SceneEntity.Destroy(sceneEntity);
		}

		private void CreateNewEntity(LevelEntityData wallData, Transform container)
		{
			var newEntity = SceneEntity.Instantiate(
				_prefabs[wallData.Id],
				wallData.Position,
				wallData.Rotation,
				container);

			newEntity.transform.localScale = wallData.Scale;
		}

		private void SetupExistingEntity(IEntity sceneEntity, LevelEntityData entityData)
		{
			var entityTransform = sceneEntity.GetVisualTransform();
			entityTransform.SetPositionAndRotation(entityData.Position, entityData.Rotation);
			entityTransform.localScale = entityData.Scale;
		}
	}
}