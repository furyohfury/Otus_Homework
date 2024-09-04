namespace Entities
{
	public sealed class DestroyComponent : IComponent
	{
        private readonly GameObject _gameObject;
        
        public DestroyComponent(GameObject gameObject)
        {
            _gameObject = gameObject;
        }

        public void Destroy()
        {
            Object.Destroy(_gameObject);
        }
    }
}