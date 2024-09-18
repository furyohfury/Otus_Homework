using System;
using System.Collections.Generic;
using UnityEngine;

namespace Entities
{
	public class Entity : MonoBehaviour
	{
		private readonly Dictionary<Type, IComponent> _components = new();

		public void AddData(IComponent component)
		{
			_components.Add(component.GetType(), component);
		}

		public bool HasData<T>() where T : IComponent
		{
			return _components.ContainsKey(typeof(T));
		}

		public bool TryRemoveData<T>() where T : IComponent
		{
			var type = typeof(T);
			if (_components.ContainsKey(type))
			{
				_components.Remove(type);
				return true;
			}

			return false;
		}

		public bool TryGetData<T>(out T component)
		{
			var type = typeof(T);
			if (_components.TryGetValue(type, out var tComponent))
			{
				component = (T)tComponent;
				return true;
			}

			component = default;
			return false;
		}

		public T GetData<T>() where T : IComponent
		{
			return (T)_components[typeof(T)];
		}

		public void RemoveData<T>() where T : IComponent
		{
			_components.Remove(typeof(T));
		}
	}
}