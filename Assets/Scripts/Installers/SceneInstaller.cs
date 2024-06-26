using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public class SceneInstaller : MonoInstaller
    {
        [SerializeField] private Transform _levelBackground;

        [SerializeField] private Transform _leftBorder;
        [SerializeField] private Transform _rightBorder;
        [SerializeField] private Transform _downBorder;
        [SerializeField] private Transform _topBorder;

        public override void InstallBindings()
        {
            Container.Bind<BulletSystem>().AsSingle();

            Container.BindInterfacesAndSelfTo<BulletsOutOfBoundsObserver>().AsCached().NonLazy();

            Container.BindInterfacesAndSelfTo<PlayerDeathObserver>().AsCached().NonLazy();
            Container.BindInterfacesAndSelfTo<PlayerFireController>().AsCached().NonLazy();
            Container.BindInterfacesAndSelfTo<PlayerMoveController>().AsCached().NonLazy();

            Container.Bind<EnemySystem>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<InputListener>().AsCached();
            Container.BindInterfacesAndSelfTo<LevelBackground>().AsCached();
            var levelBounds = new LevelBounds(_leftBorder, _rightBorder, _downBorder, _topBorder);
            Container.Bind<LevelBounds>().FromInstance(levelBounds).AsSingle();

            Container.Bind<GameManager>().FromComponentInHierarchy().AsSingle();
        }
    }
}
