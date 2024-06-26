using Zenject;

namespace ShootEmUp
{
    public class SceneInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<BulletSystem>().AsSingle();

            Container.BindInterfacesAndSelfTo<BulletsOutOfBoundsObserver>().AsSingle().NonLazy();

            Container.BindInterfacesAndSelfTo<PlayerDeathObserver>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<PlayerFireController>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<PlayerMoveController>().AsSingle().NonLazy();

            Container.Bind<EnemySystem>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<InputListener>().AsSingle();
        }
    }
}
