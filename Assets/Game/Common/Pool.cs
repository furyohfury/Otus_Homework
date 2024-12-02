using System.Collections.Generic;
using UnityEngine;

namespace Game
{
	public class Pool<T> where T : Component
	{
		public IReadOnlyCollection<T> ActiveItems => _activeItems;

		private readonly Transform _container;
		private readonly T _prefab;
		private readonly int _initialSize;
		private readonly int _maxSize;

		private readonly Queue<T> _inactiveItems;
		private readonly HashSet<T> _activeItems = new();

		public Pool(Transform parent, T prefab, bool fillOnCreate, int initialSize = 10, int maxSize = 20)
		{
			_initialSize = initialSize;
			_maxSize = maxSize;
			_prefab = prefab;
			_inactiveItems = new Queue<T>(initialSize);
			_container = new GameObject($"{prefab.name}Pool").transform;
			_container.SetParent(parent);
			_container.gameObject.SetActive(false);

			if (fillOnCreate)
			{
				FillPool();
			}
		}

		public virtual T Get(Transform parent, Vector2 pos, Quaternion rot)
		{
			if (_inactiveItems.TryDequeue(out var item))
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

			if (_activeItems.Add(item) == false)
			{
				Debug.LogError("Item from pool is already active");
			}

			return item;
		}

		public virtual T Get(Vector2 pos, Quaternion rot)
		{
			return Get(_container.root, pos, rot);
		}

		public virtual void Return(T item)
		{
			if (_activeItems.Remove(item) == false)
			{
				Debug.LogError("Item is already inactive");
			}

			if (_inactiveItems.Count < _maxSize)
			{
				_inactiveItems.Enqueue(item);
				item.transform.SetParent(_container);
			}
			else
			{
				Object.Destroy(item.gameObject);
			}
		}

		private T CreateItem(Transform parent, Vector2 pos, Quaternion rot)
		{
			return Object.Instantiate(_prefab, pos, rot, parent);
		}

		private void FillPool()
		{
			var pos = _container.transform.position;
			for (var i = 0; i < _initialSize; i++)
			{
				var newItem = CreateItem(_container, pos, Quaternion.identity);
				_inactiveItems.Enqueue(newItem);
			}
		}

		public void Dispose()
		{
			Object.Destroy(_container.gameObject);
		}
	}
}