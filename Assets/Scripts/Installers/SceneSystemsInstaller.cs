using UnityEngine;
using Zenject;

namespace SaveLoadHomework.Installers
{
    public sealed class SceneSystemsInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<Camera>().FromComponentInHierarchy().AsSingle();
        }
    }
}
