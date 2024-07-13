using UniRx;

namespace Lessons.Architecture.PM
{
    public class HeroPopupPresenter : IHeroPopupPresenter
    {
        public UserPresenter UserPresenter { get; private set; }
        public PlayerLevelPresenter PlayerLevelPresenter { get; private set; }
        public CharacterAllStatsPresenter CharacterAllStatsPresenter { get; private set; }
        public LevelUpButtonPresenter LevelUpButtonPresenter { get; private set; }

        private CompositeDisposable _disposable = new();

        public HeroPopupPresenter(UserPresenterFactory _userPresenterFactory) // model and presenter factory(ies)
        {
            UserPresenter = _userPresenterFactory.Create();
        }

        public void Dispose()
        {
            _disposable.Clear();
        }
    }
}