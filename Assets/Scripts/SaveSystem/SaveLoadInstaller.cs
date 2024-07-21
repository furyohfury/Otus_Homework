using UnityEngine;
using Zenject;

namespace Lessons.Architecture.SaveLoad
{
    public sealed class SaveLoadInstaller : MonoInstaller
    {
        [SerializeField]
        private UnitPrefabsConfig _unitPrefabsConfig;

        public override void InstallBindings()
        {
            Container.Bind<ISaveLoader>().To<UnitsSaveLoader>().AsCached();
            Container.Bind<ISaveLoader>().To<ResourcesSaveLoader>().AsCached();

            Container.Bind<UnitPrefabsConfig>().FromInstance(_unitPrefabsConfig).AsSingle();

            Container.Bind<GameRepository>().AsSingle();
            Container.Bind<SaveLoadManager>().FromComponentInHierarchy().AsSingle();
        }
    }
}
