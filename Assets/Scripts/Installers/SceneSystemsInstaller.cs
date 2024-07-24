using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace GameEngine.Installers
{
    public sealed class SceneSystemsInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<Camera>().FromComponentInHierarchy().AsSingle();
        }
    }
}
