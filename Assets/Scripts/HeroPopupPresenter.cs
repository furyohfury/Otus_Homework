namespace Lessons.Architecture.PM
{
    public class HeroPopupPresenter : IHeroPopupPresenter
    {
        public UserPresenter UserPresenter {get; private set; }
            public PlayerLevelPresenter PlayerLevelPresenter {get;private set; }
            public CharacterAllStatsPresenter CharacterAllStatsPresenter {get; private set; }
            public LevelUpButtonPresenter LevelUpButtonPresenter {get;private set; }

        public HeroPopupPresenter(UserPresenterFactory _userPresenterFactory) //factory and model
        {
            UserPresenter = _userPresenterFactory.Create();
        }
    }
}