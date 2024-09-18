using System;
using System.Collections.Generic;
using UnityEngine;

namespace Entities
{
	public class Entity : MonoBehaviour
	{
		protected readonly Dictionary<Type, IComponent> Components = new();

		public void AddData(IComponent component)
		{
			Components.Add(component.GetType(), component);
		}

		public bool HasData<T>() where T : IComponent
		{
			return Components.ContainsKey(typeof(T));
		}

		public bool TryRemoveData<T>() where T : IComponent
		{
			var type = typeof(T);
			if (Components.ContainsKey(type))
			{
				Components.Remove(type);
				return true;
			}

			return false;
		}

		public bool TryGetData<T>(out T component)
		{
			var type = typeof(T);
			if (Components.TryGetValue(type, out var tComponent))
			{
				component = (T)tComponent;
				return true;
			}

			component = default;
			return false;
		}

		public T GetData<T>() where T : IComponent
		{
			return (T)Components[typeof(T)];
		}

		public void RemoveData<T>() where T : IComponent
		{
			Components.Remove(typeof(T));
		}
	}
}