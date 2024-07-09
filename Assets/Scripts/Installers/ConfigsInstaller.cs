using UnityEngine;
using Zenject;

namespace Lessons.Architecture.PM
{
    public sealed class ConfigsInstaller : ScriptableObjectInstaller
    {
        [SerializeField]
        private CharacterConfig _characterConfig;
        [SerializeField]
        private UserConfig _userConfig;

        public override void InstallBindings()
        {
            Container.Bind<CharacterConfig>().FromInstance(_characterConfig).AsCached();
            Container.Bind<UserConfig>().FromInstance(_userConfig).AsCached();
        }
    }
}
