using System;
using Sirenix.OdinInspector;
using UniRx;

namespace Lessons.Architecture.PM
{
    public sealed class PlayerLevelPresenterFactory
    {
        private PlayerLevel _playerLevel;

        public UserPresenterFactory(PlayerLevel playerLevel)
        {
            _playerLevel=playerLevel;
        }

        public PlayerLevel Create() => new PlayerLevel(_playerLevel);
    }
}