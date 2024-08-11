using Atomic.Objects;
using GameEngine;
using TMPro;
using UnityEngine;
using Zenject;

namespace Installers
{
    public sealed class UIInstaller : MonoInstaller
    {
        [SerializeField]
        private TMP_Text _playerHP;
        [SerializeField]
        private TMP_Text _playerBullets;
        [SerializeField]
        private TMP_Text _playerKillCount;
        [SerializeField]
        private AtomicObject _character;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<PlayerUIObserver>()
                .AsCached()
                .WithArguments(
                _playerHP, 
                _playerBullets, 
                _playerKillCount, 
                _character);
        }
    }
}
