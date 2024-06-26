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
            Container.BindInterfacesAndSelfTo<UIStateController>().AsSingle();
        }
    }
}
