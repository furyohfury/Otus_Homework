using UniRx;

namespace Lessons.Architecture.PM
{
    public sealed class PlayerLevelPresenter : IPlayerLevelPresenter
    {
        public ReactiveProperty<string> Level { get; private set; } = new();
        public ReactiveProperty<string> Experience { get; private set; } = new();
        public ReactiveProperty<float> ProgressBarFillRate { get; private set; } = new();

        private PlayerLevel _playerLevel;
        private CompositeDisposable _disposable = new();

        public PlayerLevelPresenter(PlayerLevel playerLevel)
        {
            _playerLevel = playerLevel;

            _playerLevel.CurrentLevel
                .Subscribe(level => Level.Value = level.ToString())
                .AddTo(_disposable);

            _playerLevel.CurrentExperience
                .Subscribe(exp =>
                {
                    int reqExp = _playerLevel.RequiredExperience;
                    var expRatio = (float)exp / (float) reqExp;
                    Experience.Value = $"XP : {exp}/{reqExp}";
                    ProgressBarFillRate.Value = expRatio;
                })
                .AddTo(_disposable);
        }


        public void Dispose() //todo rename or add interface
        {
            _disposable.Clear();
        }
    }
}