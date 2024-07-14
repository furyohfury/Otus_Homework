using Popup.UI.Character.Level;
using Popup.UI.Character.Stats;
using Popup.UI.User;

namespace Popup.UI.Popup
{
    public sealed class HeroPopupPresenterFactory
    {
        private readonly UserPresenterFactory _userPresenterFactory;
        private readonly PlayerLevelPresentersFactory _playerLevelPresentersFactory;
        private readonly CharacterStatsPresenterFactory _characterStatsPresenterFactory;

        public HeroPopupPresenterFactory(UserPresenterFactory userPresenterFactory, PlayerLevelPresentersFactory playerLevelPresentersFactory, CharacterStatsPresenterFactory characterStatsPresenterFactory)
        {
            _userPresenterFactory = userPresenterFactory;
            _playerLevelPresentersFactory = playerLevelPresentersFactory;
            _characterStatsPresenterFactory = characterStatsPresenterFactory;
        }

        public PlayerLevelPresentersFactory PlayerLevelPresentersFactory => _playerLevelPresentersFactory;

        public HeroPopupPresenter Create() => new(_userPresenterFactory, PlayerLevelPresentersFactory, _characterStatsPresenterFactory);
    }
}