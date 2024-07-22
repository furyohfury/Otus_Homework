using UnityEngine;
using Zenject;

namespace Lessons.Architecture.SaveLoad
{
    public sealed class SaveLoadSystemsInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<GameRepository>().AsSingle();
            Container.Bind<SaveLoadManager>().FromComponentInHierarchy().AsSingle(); //todo fix to project context
        }
    }
}
