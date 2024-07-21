using Zenject;

namespace Lessons.Architecture.SaveLoad
{
    public sealed class SaveLoadInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            var unitsSaveLoader = new UnitsSaveLoader();
            ISaveLoader[] saveloaders = { unitsSaveLoader };

            Container.Bind<ISaveLoader[]>().FromInstance(saveloaders).AsSingle();
            Container.Bind<GameRepository>().AsSingle();
            Container.Bind<SaveLoadManager>().FromComponentInHierarchy().AsSingle();
        }
    }
}
