using UnityEngine;
using Zenject;

namespace Lessons.Architecture.SaveLoad
{
    public sealed class SaveLoadersInstaller : MonoInstaller
    {
        [SerializeField]
        private UnitPrefabsConfig _unitPrefabsConfig;

        public override void InstallBindings()
        {
            Container.Bind<UnitPrefabsConfig>().FromInstance(_unitPrefabsConfig).AsSingle();

            Container.Bind<ISaveLoader>().To<UnitsSaveLoader>().AsCached();
            Container.Bind<ISaveLoader>().To<ResourcesSaveLoader>().AsCached();            
        }
    }
}
