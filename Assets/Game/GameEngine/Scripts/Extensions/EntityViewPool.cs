using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public sealed class EntityViewPool
{
	private readonly Transform _container;
	private readonly List<EntityView> _pool = new();

	public EntityViewPool(Transform container = null)
	{
		if (container != null)
		{
			_container = container;
		}
		else
		{
			_container = new GameObject().transform;
		}

		_container.gameObject.name = "EntityViewPool";
		_container.gameObject.SetActive(false);
	}

	public bool TryGet(string name, out EntityView view) // hardcode((
	{
		view = _pool.FirstOrDefault(pooledView => pooledView.name == name);
		if (view != default)
		{
			_pool.Remove(view);
			return true;
		}

		return false;
	}

	public void Return(EntityView view)
	{
		_pool.Add(view);
		view.transform.parent = _container;
	}
}