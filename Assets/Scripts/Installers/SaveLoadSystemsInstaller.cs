using UnityEngine;
using Zenject;

namespace SaveLoadHomework.Installers
{
    public sealed class SaveLoadSystemsInstaller : MonoInstaller
    {
        [SerializeField]
        private SaveLoadManager _saveLoadManager;

        public override void InstallBindings()
        {
            Container.Bind<GameRepository>().AsSingle();
            Container.Bind<SaveLoadManager>().FromInstance(_saveLoadManager).AsSingle();
        }
    }
}
