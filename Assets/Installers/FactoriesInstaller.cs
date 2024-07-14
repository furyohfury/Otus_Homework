using Zenject;

namespace Lessons.Architecture.PM
{
    public sealed class FactoriesInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<HeroPopupPresenterFactory>().AsCached();
            Container.Bind<CharacterStatsPresenterFactory>().AsCached();
            Container.Bind<UserPresenterFactory>().AsCached();
            Container.Bind<PlayerLevelPresentersFactory>().AsCached();
        }
    }
}