using Popup.UI.Character.Level;
using Popup.UI.Character.Stats;
using Popup.UI.User;

namespace Popup.UI.Popup
{
    public interface IHeroPopupPresenter : IPresenter
    {
        public IUserPresenter UserPresenter { get; }
        public IPlayerLevelPresenter PlayerLevelPresenter { get; }
        public IPlayerLevelProgressBarPresenter PlayerLevelProgressBarPresenter { get; }
        public ICharacterAllStatsPresenter CharacterAllStatsPresenter { get; }
        public ILevelUpButtonPresenter LevelUpButtonPresenter { get; }

        void Dispose();
    }
}