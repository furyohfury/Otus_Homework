using UnityEngine;
using Zenject;

namespace Lessons.Architecture.PM
{
    public sealed class SystemsInstaller : MonoInstaller // SO?
    {
        [SerializeField]
        private CharacterStatView _charStatView;
        [SerializeField]
        private CharacterAllStatsView _allStatsView;

        public override void InstallBindings()
        {
            Container.Bind<UserInfo>().AsCached();
            Container.Bind<PlayerLevel>().AsCached();
            Container.Bind<CharacterInfo>().AsCached();

            Container.Bind<HeroPopupPresenterFactory>().AsCached();

            Container.Bind<CharacterStatView>().FromInstance(_charStatView).AsSingle();
            Container.Bind<CharacterAllStatsView>().FromInstance(_allStatsView).AsSingle();

            Container.Bind<PopupHelper>().FromComponentInHierarchy().AsCached();
        }
    }
}