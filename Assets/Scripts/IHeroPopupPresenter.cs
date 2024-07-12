namespace Lessons.Architecture.PM
{
    public interface IHeroPopupPresenter: IPresenter
        {
            public UserPresenter UserPresenter {get; }
            public PlayerLevelPresenter PlayerLevelPresenter {get; }
            public CharacterAllStatsPresenter CharacterAllStatsPresenter {get; }
            public LevelUpButtonPresenter LevelUpButtonPresenter {get;}
        }  
}