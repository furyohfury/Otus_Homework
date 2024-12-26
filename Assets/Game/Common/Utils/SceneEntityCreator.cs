using System;
using Atomic.Entities;
using UnityEngine;
using Zenject;

namespace Game
{
	public sealed class SceneEntityCreator : IInitializable, IDisposable
	{
		public static Func<SceneEntity, Vector3, Quaternion, Transform, SceneEntity> OnCreateEntityRequest;
		public static Action<SceneEntity> OnDestroyEntityRequest;
		private readonly IEntityWorld _entityWorld;

		[Inject]
		public SceneEntityCreator(IEntityWorld entityWorld)
		{
			_entityWorld = entityWorld;
		}


		public void Initialize()
		{
			OnCreateEntityRequest += OnCreateEntity;
			OnDestroyEntityRequest += OnRemoveEntity;
		}

		private SceneEntity OnCreateEntity(SceneEntity entity, Vector3 position, Quaternion rotation, Transform parent)
		{
			return _entityWorld.InstantiateEntity(entity, position, rotation, parent);
		}

		private void OnRemoveEntity(SceneEntity entity)
		{
			_entityWorld.DestroyEntity(entity);
		}

		public void Dispose()
		{
			OnCreateEntityRequest -= OnCreateEntity;
			OnDestroyEntityRequest -= OnRemoveEntity;
		}
	}
}