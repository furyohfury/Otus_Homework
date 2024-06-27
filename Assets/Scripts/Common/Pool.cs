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
            _prefab = prefab;
            _container = new GameObject($"{prefab.name}Pool").transform;
            _container.SetParent(parent);
            _container.gameObject.SetActive(false);            
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

        protected T CreateItem() => Object.Instantiate(_prefab, _container);

        public void FillPool(int count)
        {
            for (var i = 0; i < count; i++)
            {
                AddToPool(CreateItem());
            }
        }
    }
}