using Popup.UI;
using Popup.UI.Character.Stats;
using UnityEngine;
using Zenject;

namespace Popup.Installers
{
    public sealed class SceneInstaller : MonoInstaller
    {
        [SerializeField]
        private CharacterStatView _charStatViewPrefab;

        public override void InstallBindings()
        {
            Container.Bind<CharacterStatView>().FromInstance(_charStatViewPrefab).AsSingle();
            Container.Bind<CharacterAllStatsView>().FromComponentInHierarchy().AsCached();
            Container.Bind<PopupHelper>().FromComponentInHierarchy().AsCached();
        }
    }
}