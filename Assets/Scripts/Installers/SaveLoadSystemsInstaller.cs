using UnityEngine;
using Zenject;

namespace Lessons.Architecture.SaveLoad
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
