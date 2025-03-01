using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Game
{
	public sealed class SceneEntityPool : Pool<SceneEntity>
	{
		private readonly IEvent<IEntity> _spawnWorldEvent;
		private readonly IEvent<IEntity> _destroyWorldEvent;

		public SceneEntityPool(Transform parent, SceneEntity prefab, bool fillOnCreate, int initialSize = 10, int maxSize = 20
			, IEvent<IEntity> spawnWorldEvent = null, IEvent<IEntity> destroyWorldEvent = null)
			: base(parent, prefab, false, initialSize, maxSize)
		{
			_spawnWorldEvent = spawnWorldEvent;
			_destroyWorldEvent = destroyWorldEvent;
			if (fillOnCreate)
			{
				FillPool();
			}
		}

		protected override SceneEntity CreateItem(Transform parent, Vector2 pos, Quaternion rot)
		{
			var newItem = Object.Instantiate(Prefab, pos, rot, parent);
			_spawnWorldEvent?.Invoke(newItem);
			return newItem;
		}

		public override void Dispose()
		{
			base.Dispose();
			foreach (var entity in ActiveItems)
			{
				_destroyWorldEvent?.Invoke(entity);
				Object.Destroy(entity.gameObject);
			}

			foreach (var entity in InactiveItems)
			{
				_destroyWorldEvent?.Invoke(entity);
				Object.Destroy(entity.gameObject);
			}
		}
	}
}