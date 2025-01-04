using System;
using System.Collections.Generic;
using System.Linq;
using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace SaveLoad
{
	public sealed class SceneEntitiesSaveLoader : SaveLoader<IEnumerable<SceneEntityData>, IEntityWorld>
	{
		protected override IEnumerable<SceneEntityData> ConvertToData(IEntityWorld world)
		{
			IReadOnlyList<IEntity> entities = world.Entities;
			var entitiesData = new SceneEntityData[entities.Count];

			for (int i = 0; i < entities.Count; i++)
			{
				if (entities[i] is not SceneEntity sceneEntity)
				{
					continue;
				}

				var id = sceneEntity.InstanceId;
				var transform = sceneEntity.transform;
				var pos = transform.position;
				var rot = transform.rotation;
				var scale = transform.localScale;
				
				var savedValues = new Dictionary<int,object>();
				foreach (KeyValuePair<int,object> valuePair in sceneEntity.Values)
				{
					if (valuePair.Value is not Component)
					{
						savedValues.Add(valuePair.Key, valuePair.Value);
					}
				}
				entitiesData[i] = new SceneEntityData(id, pos, rot, scale, savedValues);
			}

			return entitiesData;
		}

		protected override void SetupData(IEntityWorld world, IEnumerable<SceneEntityData> data)
		{
			foreach (var entityData in data)
			{
				var worldEntity = world.Entities.SingleOrDefault(entity => entity.InstanceId == entityData.InstanceId);

				// If already in world
				if (worldEntity is SceneEntity sceneEntity)
				{
					SetEntityState(sceneEntity, entityData);
				}
			}
		}

		private void SetEntityState(SceneEntity sceneEntity, SceneEntityData entityData)
		{
			var states = entityData.State;
			foreach (KeyValuePair<int, object> state in states)
			{
				int key = state.Key;
				if (sceneEntity.TryGetValue(key, out var entityValue) && entityValue is IValueBase valueBase)
				{
					var value = (state.Value as IValueBase)?.GetValue();
					valueBase.SetValue(value);
				}
			}

			var entityTransform = sceneEntity.transform;
			entityTransform.position = entityData.Position;
			entityTransform.rotation = entityData.Rotation;
			entityTransform.localScale = entityData.Scale;
		}
	}
}