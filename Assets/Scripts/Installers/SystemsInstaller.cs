using Zenject;

namespace Lessons.Architecture.PM
{
    public sealed class SystemInstaller : MonoInstaller // SO?
    {
        [SerializeField]
        private CharacterStatView _charStatView;

        public override void InstallBindings()
        {
            Container.Bind<UserInfo>().AsCached();
            Container.Bind<PlayerLevel>().AsCached();
            Container.Bind<CharacterInfo>().AsCached();

            Container.Bind<UserPresenterFactory>().AsCached();
            Container.Bind<PlayerLevelPresenterFactory>().AsCached();
            Container.Bind<CharacterAllStatsPresenterFactory>().AsCached();

            Container.Bind<CharacterStatView>().FromInstance(_charStatView).AsSingle();
        }
    }
}