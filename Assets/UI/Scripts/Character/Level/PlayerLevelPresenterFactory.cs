using System;
using Sirenix.OdinInspector;
using UniRx;

namespace Lessons.Architecture.PM
{
    public sealed class PlayerLevelPresenterFactory
    {
        private PlayerLevel _playerLevel;

        public PlayerLevelPresenterFactory(PlayerLevel playerLevel)
        {
            _playerLevel=playerLevel;
        }

        public PlayerLevelPresenter Create() => new PlayerLevelPresenter(_playerLevel);
    }
}