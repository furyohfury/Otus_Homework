namespace Lessons.Architecture.PM
{
    public class HeroPopupPresenter : IHeroPopupPresenter
    {
        public IUserPresenter UserPresenter { get; private set; }
        public IPlayerLevelPresenter PlayerLevelPresenter { get; private set; }
        public IPlayerLevelProgressBarPresenter PlayerLevelProgressBarPresenter { get; private set; }
        public ICharacterAllStatsPresenter CharacterAllStatsPresenter { get; private set; }
        public ILevelUpButtonPresenter LevelUpButtonPresenter { get; private set; }

        public HeroPopupPresenter(UserInfo userInfo, CharacterInfo characterInfo, PlayerLevel playerLevel) // todo make factories?
        {
            UserPresenter = new UserPresenter(userInfo);
            PlayerLevelPresenter = new PlayerLevelPresenter(playerLevel);
            PlayerLevelProgressBarPresenter = new PlayerLevelProgressBarPresenter(playerLevel);
            CharacterAllStatsPresenter = new CharacterAllStatsPresenter(characterInfo);
            LevelUpButtonPresenter = new LevelUpButtonPresenter(playerLevel);
        }
    }
}