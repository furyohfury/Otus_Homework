using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public class LevelInstaller : MonoInstaller
    {
        [SerializeField] private Transform _levelBackground;

        [SerializeField] private Transform _leftBorder;
        [SerializeField] private Transform _rightBorder;
        [SerializeField] private Transform _downBorder;
        [SerializeField] private Transform _topBorder;
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<LevelBackground>().AsCached().WithArguments(_levelBackground);

            LevelBounds levelBounds = new(_leftBorder, _rightBorder, _downBorder, _topBorder);
            Container.Bind<LevelBounds>().FromInstance(levelBounds).AsSingle();
        }
    }
}