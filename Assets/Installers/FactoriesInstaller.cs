using Popup.UI.Character.Level;
using Popup.UI.Character.Stats;
using Popup.UI.Popup;
using Popup.UI.User;
using Zenject;

namespace Popup.Installers
{
    public sealed class FactoriesInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<HeroPopupPresenterFactory>().AsCached();
            Container.Bind<CharacterStatsPresenterFactory>().AsCached();
        }
    }
}