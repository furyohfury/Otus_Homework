namespace Lessons.Architecture.PM
{
    public sealed class HeroPopupPresenterFactory
    {
        private readonly UserInfo _userInfo;
        private readonly CharacterInfo _characterInfo;
        private readonly PlayerLevel _playerLevel;

        public HeroPopupPresenterFactory(UserInfo userInfo, CharacterInfo characterInfo, PlayerLevel playerLevel)
        {
            _userInfo = userInfo;
            _characterInfo = characterInfo;
            _playerLevel = playerLevel;
        }

        public HeroPopupPresenter Create() => new(_userInfo, _characterInfo, _playerLevel);
    }
}