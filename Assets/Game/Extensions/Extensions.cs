using Zenject;

namespace Game
{
    public class Extensions
    {
        public T CreateInstance<T>(this DiContainer) // TODO test
        {
            var instance = new T();
            Inject(instance);
            return instance;
        }
    }
}