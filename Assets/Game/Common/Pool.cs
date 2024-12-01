// using System;
// using UnityEngine;
// using UnityEngine.Pool;
// using Object = UnityEngine.Object;
//
// namespace Game
// {
// 	public class Pool<T> where T : Object 
// 	{
// 		private Transform _container;
// 		private T _prefab;
// 		private ObjectPool<T> _pool;
//
// 		public Pool(Transform container, T prefab, int capacity = 10, int maxSize = 20)
// 		{
// 			var cache = new GameObject
// 			            {
// 				            transform =
// 				            {
// 					            parent = container
// 				            }
// 			            };
// 			_container = cache.transform;
// 			_prefab = prefab;
// 			_pool = new ObjectPool<T>(CreateObject, GetObject, ReleaseObject, DestroyObject, false, capacity, maxSize);
// 		}
//
// 		private void GetObject(T obj)
// 		{
// 			
// 		}
//
// 		private T CreateObject()
// 		{
// 			return Object.Instantiate(_prefab, _container);
// 		}
// 	}
// }