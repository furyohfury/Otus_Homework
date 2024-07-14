using Popup.GameData;

namespace Popup.UI.Character.Level
{
    public sealed class PlayerLevelPresentersFactory
    {
        private PlayerLevel _playerLevel;

        public PlayerLevelPresentersFactory(PlayerLevel playerLevel)
        {
            _playerLevel = playerLevel;
        }

        public PlayerLevelPresenter CreatePlayerLevelPresenter() => new PlayerLevelPresenter(_playerLevel);

        public PlayerLevelProgressBarPresenter CreatePlayerLevelProgressBarPresenter() => new PlayerLevelProgressBarPresenter(_playerLevel);

        public LevelUpButtonPresenter CreateLevelUpButtonPresenter() => new LevelUpButtonPresenter(_playerLevel);
    }
}