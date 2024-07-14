namespace Lessons.Architecture.PM
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

        public HeroPopupPresenter Create() => new(_userPresenterFactory, _playerLevelPresentersFactory, _characterStatsPresenterFactory);
    }
}