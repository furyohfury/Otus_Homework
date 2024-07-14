using Zenject;

namespace Lessons.Architecture.PM
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