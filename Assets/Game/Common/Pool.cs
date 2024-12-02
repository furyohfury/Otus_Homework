using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class Pool<T> where T : Component
    {
        public IReadonlyCollection ActiveItems => _activeItems;

        protected Transform _container;
        protected T _prefab;
        protected int _initialSize;
        protected int _maxSize;

        protected readonly Queue<T> _inactiveItems;
        protected readonly HashSet<T> _activeItems;

        public Pool(Transform parent, T prefab, bool fillOnCreate, int initialSize = 10, int maxSize = 20)
        {
            _initialSize = initialSize;
            _maxSize = maxSize;
            _prefab = prefab;
            _inactiveItems = new Queue(initialSize);
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
            T item;
            if (_inactiveItems.TryDequeue(out T item))
            {
                var transform = item.transform;
                transform.parent = parent;
                transform.position = pos;
                transform.rotation = rot;
                return item;
            }
            else
            {
                item = CreateItem(parent, pos, rot);
            }

            if (_activeItems.Add(item) == false)
            {
                Debug.LogError($"Item from pool is already active");
            }
        }

        public virtual void Return(T item)
        {
            if (_activeItems.Remove(item) == false)
            {
                Debug.LogError($"Item is already inactive");
            }

            if (_inactiveItems.Count < _maxSize)
            {
                _inactiveItems.Enqueue(item);
                item.transform.SetParent(_container);
            }
            else
            {
                Object.Destroy(item);
            }
            
        }

        protected T CreateItem(Transform parent, Vector2 pos, Quaternion rot)
        {
            return Object.Instantiate(_prefab, parent, pos, rot);
        }

        protected void FillPool(int count)
        {
            var pos = _container.transform.position;
            for (var i = 0; i < count; i++)
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