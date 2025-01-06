using System;
using Atomic.Entities;
using UnityEngine;
using Zenject;

namespace Game
{
	public sealed class SceneEntityCreator : IInitializable, IDisposable
	{
		public static Func<SceneEntity, Vector3, Quaternion, Transform, SceneEntity> OnCreateEntityRequest;
		public static Func<SceneEntity, Vector3, Quaternion, SceneEntity> OnCreateEntityInRootRequest;
		public static Action<SceneEntity> OnDestroyEntityRequest;

		private readonly IEntityWorld _entityWorld;
		private readonly Transform _worldTransform;

		[Inject]
		public SceneEntityCreator(IEntityWorld entityWorld, Transform worldTransform)
		{
			_entityWorld = entityWorld;
			_worldTransform = worldTransform;
		}


		public void Initialize()
		{
			OnCreateEntityRequest += OnCreateEntity;
			OnCreateEntityInRootRequest += OnCreateEntityInRoot;
			OnDestroyEntityRequest += OnRemoveEntity;
		}

		private SceneEntity OnCreateEntity(SceneEntity entity, Vector3 position, Quaternion rotation, Transform parent)
		{
			return _entityWorld.InstantiateEntity(entity, position, rotation, parent);
		}

		private SceneEntity OnCreateEntityInRoot(SceneEntity entity, Vector3 position, Quaternion rotation)
		{
			return OnCreateEntity(entity, position, rotation, _worldTransform);
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