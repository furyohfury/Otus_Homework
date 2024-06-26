using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public class Pool<T> where T : MonoBehaviour
    {
        protected Transform _container;
        protected T _prefab;

        protected readonly Queue<T> _cache = new();

        public Pool(Transform parent, T prefab)
        {
            _container = new GameObject($"{_prefab.name}Pool").transform;
            _container.parent = parent;
            _container.gameObject.SetActive(false);
            _prefab = prefab;
        }

        public virtual T TakeItemFromPool()
        {
            if (_cache.TryDequeue(out T item))
            {
                return item;
            }
            else
            {
                return CreateItem();
            }
        }

        public virtual void AddToPool(T item)
        {
            _cache.Enqueue(item);
            item.transform.SetParent(_container);
        }

        protected T CreateItem()
        {
            return Object.Instantiate(_prefab, _container);
        }

        public void FillPool(int count)
        {
            for (var i = 0; i < count; i++)
            {
                AddToPool(CreateItem());
            }
        }
    }
}