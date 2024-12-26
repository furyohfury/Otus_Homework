using Atomic.Entities;
using UnityEngine;

namespace Game
{
	public sealed class SceneEntityPool : Pool<SceneEntity>
	{
		public SceneEntityPool(Transform parent, SceneEntity prefab, bool fillOnCreate, int initialSize = 10, int maxSize = 20) : base(parent, prefab
			, fillOnCreate, initialSize, maxSize)
		{ }

		protected override SceneEntity CreateItem(Transform parent, Vector2 pos, Quaternion rot)
		{
			return SceneEntityCreator.OnCreateEntityRequest.Invoke(Prefab, pos, rot, parent);
		}

		public override void Dispose()
		{
			base.Dispose();
			foreach (var entity in ActiveItems)
			{
				SceneEntityCreator.OnDestroyEntityRequest(entity);
			}
			
			foreach (var entity in InactiveItems)
			{
				SceneEntityCreator.OnDestroyEntityRequest(entity);
			}
		}
	}
}