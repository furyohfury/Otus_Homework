namespace Lessons.Architecture.PM
{
    public class HeroPopupPresenter : IHeroPopupPresenter
    {
        public UserPresenter UserPresenter { get; private set; }
        public PlayerLevelPresenter PlayerLevelPresenter { get; private set; }
        public CharacterAllStatsPresenter CharacterAllStatsPresenter { get; private set; }
        public LevelUpButtonPresenter LevelUpButtonPresenter { get; private set; }

        public HeroPopupPresenter(UserInfo userInfo, CharacterInfo characterInfo, PlayerLevel playerLevel) // todo make factories?
        {
            UserPresenter = new(userInfo);
            PlayerLevelPresenter = new(playerLevel);
            CharacterAllStatsPresenter = new(characterInfo);
            LevelUpButtonPresenter = new(playerLevel);
        }

        public void Dispose() { } // todo fix i dunno
    }
}