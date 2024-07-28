using Zenject;

namespace SaveLoadHomework
{
    public abstract class SaveLoader<TData, TService> : ISaveLoader
    {
        void ISaveLoader.LoadGame(IGameRepository repository, SceneContext context)
        {
            var service = context.Container.Resolve<TService>();
            if (repository.TryGetData(out TData data))
            {
                SetupData(service, data);
            }
            else
            {
                SetupByDefault(service);
            }
        }

        void ISaveLoader.SaveGame(IGameRepository repository, SceneContext context)
        {
            var service = context.Container.Resolve<TService>();
            var data = ConvertToData(service);
            repository.SetData(data);
        }

        protected abstract void SetupData(TService service, TData data);

        protected abstract TData ConvertToData(TService service);

        protected virtual void SetupByDefault(TService service)
        {
            throw new System.Exception($"Didn't find data to service: {service.GetType().Name}");
        }
    }
}