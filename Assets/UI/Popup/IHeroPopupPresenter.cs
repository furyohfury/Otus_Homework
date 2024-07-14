namespace Lessons.Architecture.PM
{
    public interface IHeroPopupPresenter : IPresenter
    {
        public IUserPresenter UserPresenter { get; }
        public IPlayerLevelPresenter PlayerLevelPresenter { get; }
        public IPlayerLevelProgressBarPresenter PlayerLevelProgressBarPresenter { get; }
        public ICharacterAllStatsPresenter CharacterAllStatsPresenter { get; }
        public ILevelUpButtonPresenter LevelUpButtonPresenter { get; }
    }
}