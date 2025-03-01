using System.Collections;
using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Game
{
	[AddComponentMenu("Atomic/Entities/Entity spawn tracking world")]
	[DisallowMultipleComponent]
	[DefaultExecutionOrder(-10050)]
	public class EntitySpawnTrackingWorld : SceneEntityWorld
	{
		protected override void Start()
		{
			base.Start();
			StartCoroutine(SubscribeToSpawners());
		}

		private IEnumerator SubscribeToSpawners()
		{
			// After all entities got installed spawn/destroy events
			yield return null;
			for (int i = 0, count = _world.EntityCount; i < count; i++)
			{
				var entity = _world.Entities[i];
				if (entity.TryGetSpawnWorldEvent(out IEvent<Object> spawnEvent))
				{
					spawnEvent.Subscribe(OnEntitySpawned);
				}

				if (entity.TryGetDestroyWorldEvent(out IEvent<Object> destroyEvent))
				{
					destroyEvent.Subscribe(OnEntityDestroyed);
				}
			}
		}

		private void OnEntitySpawned(Object obj)
		{
			if (obj is not IEntity sceneEntity)
			{
				return;
			}

			_world.AddEntity(sceneEntity);
			if (sceneEntity.TryGetSpawnWorldEvent(out IEvent<Object> spawnEvent))
			{
				spawnEvent.Subscribe(OnEntitySpawned);
			}
		}

		private void OnEntityDestroyed(Object obj)
		{
			if (obj is not IEntity sceneEntity)
			{
				return;
			}

			_world.DelEntity(sceneEntity);
			if (sceneEntity.TryGetSpawnWorldEvent(out IEvent<Object> spawnEvent))
			{
				spawnEvent.Unsubscribe(OnEntitySpawned);
			}

			if (sceneEntity.TryGetDestroyWorldEvent(out IEvent<Object> destroyEvent))
			{
				destroyEvent.Unsubscribe(OnEntityDestroyed);
			}
		}
	}
}