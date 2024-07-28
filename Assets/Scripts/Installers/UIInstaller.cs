using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI.Installers
{
    public sealed class UIInstaller : MonoInstaller
    {
        [SerializeField]
        private Button _saveButton;
        [SerializeField]
        private Button _loadButton;
        [SerializeField]
        private Button _killButton;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<SaveLoadUIController>().AsSingle().WithArguments(_saveButton, _loadButton);
            Container.BindInterfacesAndSelfTo<KillUnitUIController>().AsSingle().WithArguments(_killButton);
        }
    }
}
