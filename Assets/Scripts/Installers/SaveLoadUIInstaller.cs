using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI
{
    public sealed class SaveLoadUIInstaller : MonoInstaller
    {
        [SerializeField]
        private Button _saveButton;
        [SerializeField]
        private Button _loadButton;
        [SerializeField]
        private Button _killButton; // in separate installer

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<SaveLoadUIPresenter>().AsSingle().WithArguments(_saveButton, _loadButton);
            Container.BindInterfacesAndSelfTo<KillUnitPresenter>().AsSingle().WithArguments(_killButton);
        }
    }
}
