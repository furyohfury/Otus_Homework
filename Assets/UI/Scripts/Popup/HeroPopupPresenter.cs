using Popup.UI.Character.Level;
using Popup.UI.Character.Stats;
using Popup.UI.User;

namespace Popup.UI.Popup
{
    public class HeroPopupPresenter : IHeroPopupPresenter
    {
        public IUserPresenter UserPresenter { get; private set; }
        public IPlayerLevelPresenter PlayerLevelPresenter { get; private set; }
        public IPlayerLevelProgressBarPresenter PlayerLevelProgressBarPresenter { get; private set; }
        public ICharacterAllStatsPresenter CharacterAllStatsPresenter { get; private set; }
        public ILevelUpButtonPresenter LevelUpButtonPresenter { get; private set; }

        public HeroPopupPresenter(IUserPresenter userPresenter, IPlayerLevelPresenter playerLevelPresenter, IPlayerLevelProgressBarPresenter playerLevelProgressBarPresenter, ICharacterAllStatsPresenter characterAllStatsPresenter, ILevelUpButtonPresenter levelUpButtonPresenter)
        {
            UserPresenter = userPresenter;
            PlayerLevelPresenter = playerLevelPresenter;
            PlayerLevelProgressBarPresenter = playerLevelProgressBarPresenter;
            CharacterAllStatsPresenter = characterAllStatsPresenter;
            LevelUpButtonPresenter = levelUpButtonPresenter;
        }

        public void Dispose()
        {
            UserPresenter.Dispose();
            PlayerLevelPresenter.Dispose();
            PlayerLevelProgressBarPresenter.Dispose();
            CharacterAllStatsPresenter.Dispose();
            LevelUpButtonPresenter.Dispose();
        }
    }
}