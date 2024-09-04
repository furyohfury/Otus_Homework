using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Entities
{
	public class Entity : MonoBehaviour
	{
		protected readonly Dictionary<Type, IComponent> Components = new();

		public void AddData(IComponent component) => Components.Add(component.GetType(), component);

		public bool TryGetData<T>(out T component)
		{
			foreach (var entityComponent in Components)
			{
				if (entityComponent is T tcomponent)
				{
					component = tcomponent;
					return true;
				}
			}

			component = default;
			return false;
		}

		protected T GetData<T>() => (T) Components[typeof(T)];
	}
}