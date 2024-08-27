public sealed class EntityViewPool
{
    private Transform _container;
    private List<EntityView> _pool = new();

	public EntityViewPool(Transform container = null)
    {
        if (parent != null)
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
        view.parent = _container;
    }
}