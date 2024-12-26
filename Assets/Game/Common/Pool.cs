using System.Collections.Generic;
using UnityEngine;

namespace Game
{
	public class Pool<T> where T : Component
	{
		public IReadOnlyCollection<T> GetActiveItems => ActiveItems;

		protected readonly Transform Container;
		protected readonly T Prefab;
		protected readonly int InitialSize;
		protected readonly int MaxSize;

		protected readonly Queue<T> InactiveItems;
		protected readonly HashSet<T> ActiveItems = new();

		public Pool(Transform parent, T prefab, bool fillOnCreate, int initialSize = 10, int maxSize = 20)
		{
			InitialSize = initialSize;
			MaxSize = maxSize;
			Prefab = prefab;
			InactiveItems = new Queue<T>(initialSize);
			Container = new GameObject($"{prefab.name}Pool").transform;
			Container.SetParent(parent);
			Container.gameObject.SetActive(false);

			if (fillOnCreate)
			{
				FillPool();
			}
		}

		public virtual T Get(Transform parent, Vector2 pos, Quaternion rot)
		{
			if (InactiveItems.TryDequeue(out var item))
			{
				var transform = item.transform;
				transform.parent = parent;
				transform.position = pos;
				transform.rotation = rot;
			}
			else
			{
				item = CreateItem(parent, pos, rot);
			}

			if (ActiveItems.Add(item) == false)
			{
				Debug.LogError("Item from pool is already active");
			}

			return item;
		}

		public virtual T Get(Vector2 pos, Quaternion rot)
		{
			return Get(Container.root, pos, rot);
		}

		public virtual void Return(T item)
		{
			if (ActiveItems.Remove(item) == false)
			{
				Debug.LogError("Item is already inactive");
			}

			if (InactiveItems.Count < MaxSize)
			{
				InactiveItems.Enqueue(item);
				item.transform.SetParent(Container);
			}
			else
			{
				Object.Destroy(item.gameObject);
			}
		}

		protected virtual T CreateItem(Transform parent, Vector2 pos, Quaternion rot)
		{
			return Object.Instantiate(Prefab, pos, rot, parent);
		}

		private void FillPool()
		{
			var pos = Container.transform.position;
			for (var i = 0; i < InitialSize; i++)
			{
				var newItem = CreateItem(Container, pos, Quaternion.identity);
				InactiveItems.Enqueue(newItem);
			}
		}

		public virtual void Dispose()
		{
			Object.Destroy(Container.gameObject);
		}
	}
}