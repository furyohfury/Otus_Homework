using System.Collections.Generic;
using System.Linq;
using Atomic.Entities;
using UnityEngine;
using Zenject;

namespace SaveLoad
{
	public sealed class DestructibleWallsSaveLoader : SaveLoader<IEnumerable<DestructibleWallData>, IEntityWorld>
	{
		private readonly SceneEntity _prefab;

		[Inject]
		public DestructibleWallsSaveLoader(SceneEntity prefab)
		{
			_prefab = prefab;
		}

		protected override IEnumerable<DestructibleWallData> ConvertToData(IEntityWorld service)
		{
			IReadOnlyList<IEntity> walls = service.GetEntitiesWithTag(TagAPI.DestructibleWall);
			DestructibleWallData[] data = new DestructibleWallData[walls.Count];
			for (int i = 0, count = data.Length; i < count; i++)
			{
				var wallTransform = walls[i].GetVisualTransform();
				var instanceId = walls[i].InstanceId;
				data[i] = new DestructibleWallData(
					wallTransform.position,
					wallTransform.rotation,
					instanceId);
			}

			return data;
		}

		protected override void SetupData(IEntityWorld service, IEnumerable<DestructibleWallData> data)
		{
			var sceneWalls = service.GetEntitiesWithTag(TagAPI.DestructibleWall).ToArray();
			var world = Object.FindObjectOfType<SceneEntityWorld>();
			var worldTransform = world.transform;
			IEnumerable<DestructibleWallData> destructibleWallDatas = data.ToArray();

			foreach (var sceneWall in sceneWalls)
			{
				if (destructibleWallDatas.Any(wallData => wallData.InstanceId == sceneWall.InstanceId) == false)
				{
					SceneEntity.Destroy(sceneWall);
				}
			}

			foreach (var wallData in destructibleWallDatas)
			{
				var sceneWall = sceneWalls.SingleOrDefault(sceneEnemy => sceneEnemy.InstanceId == wallData.InstanceId);
				if (sceneWall == default)
				{
					CreateNewWall(wallData, worldTransform);
				}
			}
		}

		private void CreateNewWall(DestructibleWallData wallData, Transform worldTransform)
		{
			SceneEntity.Instantiate(
				_prefab,
				wallData.Position,
				wallData.Rotation,
				worldTransform);
		}
	}
}