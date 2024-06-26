using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace ShootEmUp
{
    public class UIInstaller : MonoInstaller
    {
        [SerializeField] private Button _pauseButton;
        [SerializeField] private Button _startButton;

        public override void InstallBindings()
        {
            Container.Bind<Button>().FromInstance(_pauseButton).AsCached().WhenInjectedInto<GamePauseObserver>();
            Container.Bind<Button>().FromInstance(_startButton).AsCached().WhenInjectedInto<GameLauncher>();

            UIStateController uIStateController = new(_pauseButton, _startButton);
            Container.BindInterfacesAndSelfTo<UIStateController>().FromInstance(uIStateController).AsCached().NonLazy();
        }
    }
}
