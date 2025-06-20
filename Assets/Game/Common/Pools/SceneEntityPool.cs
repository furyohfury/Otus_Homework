using Atomic.Entities;
using UnityEngine;

namespace Game
{
	public sealed class SceneEntityPool : Pool<SceneEntity>
	{
		public SceneEntityPool(Transform parent, SceneEntity prefab, bool fillOnCreate, int initialSize = 10, int maxSize = 20)
			: base(parent, prefab, false, initialSize, maxSize)
		{
			if (fillOnCreate)
			{
				FillPool();
			}
		}

		protected override SceneEntity CreateItem(Transform parent, Vector2 pos, Quaternion rot)
		{
			var newItem = SceneEntity.Instantiate(Prefab, pos, rot, parent);
			return newItem;
		}

		protected override void DestroyItem(SceneEntity item)
		{
			SceneEntity.Destroy(item);
		}

		public override void Dispose()
		{
			foreach (var sceneEntity in InactiveItems)
			{
				SceneEntity.Destroy(sceneEntity);
			}

			base.Dispose();
		}
	}
}