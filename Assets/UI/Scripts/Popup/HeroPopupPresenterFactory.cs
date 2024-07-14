using Popup.GameData;
using Popup.UI.Character.Level;
using Popup.UI.Character.Stats;
using Popup.UI.User;

namespace Popup.UI.Popup
{
    public sealed class HeroPopupPresenterFactory
    {
        private readonly UserInfo _userInfo;
        private readonly PlayerLevel _playerLevel;
        private readonly CharacterStatsPresenterFactory _characterStatsPresenterFactory;

        public HeroPopupPresenterFactory(UserInfo userInfo, PlayerLevel playerLevel, CharacterStatsPresenterFactory characterStatsPresenterFactory)
        {
            _userInfo = userInfo;
            _playerLevel = playerLevel;
            _characterStatsPresenterFactory = characterStatsPresenterFactory;
        }

        public HeroPopupPresenter Create()
        {
            var userPresenter = new UserPresenter(_userInfo);
            var playerLevelPresenter = new PlayerLevelPresenter(_playerLevel);
            var playerLevelProgressBarPresenter = new PlayerLevelProgressBarPresenter(_playerLevel);
            var levelUpButtonPresenter = new LevelUpButtonPresenter(_playerLevel);
            var characterStatsPresenter = new CharacterAllStatsPresenter(_characterStatsPresenterFactory);          
            return new HeroPopupPresenter(userPresenter, playerLevelPresenter, playerLevelProgressBarPresenter, characterStatsPresenter, levelUpButtonPresenter);
        }
    }
}