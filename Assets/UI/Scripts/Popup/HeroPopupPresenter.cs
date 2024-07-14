using Popup.UI.Character.Level;
using Popup.UI.Character.Stats;
using Popup.UI.User;

namespace Popup.UI.Popup
{
    public class HeroPopupPresenter : IHeroPopupPresenter
    {
        private IPlayerLevelProgressBarPresenter _playerLevelProgressBarPresenter;

        public IUserPresenter UserPresenter { get; private set; }
        public IPlayerLevelPresenter PlayerLevelPresenter { get; private set; }
        public IPlayerLevelProgressBarPresenter PlayerLevelProgressBarPresenter { get => _playerLevelProgressBarPresenter; private set => _playerLevelProgressBarPresenter = value; }
        public ICharacterAllStatsPresenter CharacterAllStatsPresenter { get; private set; }
        public ILevelUpButtonPresenter LevelUpButtonPresenter { get; private set; }

        public HeroPopupPresenter(UserPresenterFactory userPresenterFactory, PlayerLevelPresentersFactory playerLevelPresentersFactory, CharacterStatsPresenterFactory characterStatsPresenterFactory)
        {
            UserPresenter = userPresenterFactory.Create();
            PlayerLevelPresenter = playerLevelPresentersFactory.CreatePlayerLevelPresenter();
            PlayerLevelProgressBarPresenter = playerLevelPresentersFactory.CreatePlayerLevelProgressBarPresenter();
            CharacterAllStatsPresenter = new CharacterAllStatsPresenter(characterStatsPresenterFactory);
            LevelUpButtonPresenter = playerLevelPresentersFactory.CreateLevelUpButtonPresenter();
        }
    }
}