using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public class Pool<T> : MonoBehaviour where T : MonoBehaviour
    {
        [SerializeField] protected Transform _container;        

        protected readonly Queue<T> _cache = new();

        public virtual bool TryTakeItemFromPool(out T item)
        {
            if (_cache.TryDequeue(out item))
            {
                return true;
            }
            else
            {
                item = default;
                return false;
            }
        }

        public virtual void AddToPool(T obj)
        {
            _cache.Enqueue(obj);
            obj.transform.SetParent(_container);
        }
    }
}