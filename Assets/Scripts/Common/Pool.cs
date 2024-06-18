using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public class Pool<T> : MonoBehaviour where T : MonoBehaviour
    {
        
        [SerializeField] protected Transform _container;
        [SerializeField] protected T _prefab;        

        protected readonly Queue<T> _cache = new();

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
            return Instantiate(_prefab, _container);
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