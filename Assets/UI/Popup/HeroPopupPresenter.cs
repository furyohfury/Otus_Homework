namespace Lessons.Architecture.PM
{
    public class HeroPopupPresenter : IHeroPopupPresenter
    {
        public IUserPresenter UserPresenter { get; private set; }
        public IPlayerLevelPresenter PlayerLevelPresenter { get; private set; }
        public IPlayerLevelProgressBarPresenter PlayerLevelProgressBarPresenter { get; private set; }
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
    public sealed class PlayerLevelPresentersFactory
    {
        private PlayerLevel _playerLevel;

        public PlayerLevelPresentersFactory(PlayerLevel playerLevel)
        {
            _playerLevel = playerLevel;
        }

        public PlayerLevelPresenter CreatePlayerLevelPresenter() => new PlayerLevelPresenter(_playerLevel);

        public PlayerLevelProgressBarPresenter CreatePlayerLevelProgressBarPresenter() => new PlayerLevelProgressBarPresenter(_playerLevel);

        public LevelUpButtonPresenter CreateLevelUpButtonPresenter() => new LevelUpButtonPresenter(_playerLevel);
    }
}