using Popup.GameData;
using Zenject;

namespace Popup.Installers
{
    public sealed class GameSystemsInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<UserInfo>().AsCached();
            Container.Bind<PlayerLevel>().AsCached();
            Container.Bind<CharacterInfo>().AsCached();
        }
    }
}