using System.Collections.Generic;
using System.Linq;
using Atomic.Entities;
using Game;
using UnityEngine;

namespace SaveLoad
{
	public sealed class LevelEntitiesSaveLoader : SaveLoader<LevelEntityData[], LevelEntitiesService>
	{
		private readonly Dictionary<string, SceneEntity> _prefabs;

		public LevelEntitiesSaveLoader(Dictionary<string, SceneEntity> prefabs)
		{
			_prefabs = prefabs;
		}

		protected override LevelEntityData[] ConvertToData(LevelEntitiesService service)
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

		protected override void SetupData(LevelEntitiesService service, LevelEntityData[] data)
		{
			var sceneEntities = service.GetLevelEntities().ToArray();

			foreach (var sceneEntity in sceneEntities)
			{
				if (data.Any(entityData => entityData.InstanceId == sceneEntity.InstanceId) == false)
				{
					DestroyEntity(sceneEntity);
				}
			}

			for (int i = 0, count = data.Length; i < count; i++)
			{
				var sceneEntity = sceneEntities.SingleOrDefault(sceneEnemy => sceneEnemy.InstanceId == data[i].InstanceId);
				if (sceneEntity == default)
				{
					CreateNewEntity(data[i], service.Container);
				}
				else
				{
					SetupExistingEntity(sceneEntity, data[i]);
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