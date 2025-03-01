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
				if (entity.TryGetSpawnWorldEvent(out IEvent<IEntity> spawnEvent))
				{
					spawnEvent.Subscribe(OnEntitySpawned);
				}

				if (entity.TryGetDestroyWorldEvent(out IEvent<IEntity> destroyEvent))
				{
					destroyEvent.Subscribe(OnEntityDestroyed);
				}
			}
		}

		private void OnEntitySpawned(IEntity entity)
		{
			_world.AddEntity(entity);
			if (entity.TryGetSpawnWorldEvent(out IEvent<IEntity> spawnEvent))
			{
				spawnEvent.Subscribe(OnEntitySpawned);
			}
		}

		private void OnEntityDestroyed(IEntity entity)
		{
			_world.DelEntity(entity);
			if (entity.TryGetSpawnWorldEvent(out IEvent<IEntity> spawnEvent))
			{
				spawnEvent.Unsubscribe(OnEntitySpawned);
			}

			if (entity.TryGetDestroyWorldEvent(out IEvent<IEntity> destroyEvent))
			{
				destroyEvent.Unsubscribe(OnEntityDestroyed);
			}
		}
	}
}