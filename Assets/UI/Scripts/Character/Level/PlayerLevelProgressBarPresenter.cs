using Popup.GameData;
using UniRx;

namespace Popup.UI.Character.Level
{
    public sealed class PlayerLevelProgressBarPresenter : IPlayerLevelProgressBarPresenter
    {
        public ReactiveProperty<string> Experience { get; private set; } = new();
        public ReactiveProperty<float> ProgressBarFillRate { get; private set; } = new();

        private readonly PlayerLevel _playerLevel;
        private readonly CompositeDisposable _disposable = new();

        public PlayerLevelProgressBarPresenter(PlayerLevel playerLevel)
        {
            _playerLevel = playerLevel;
            _playerLevel.CurrentExperience
                .Subscribe(exp =>
                {
                    int reqExp = _playerLevel.RequiredExperience;
                    var expRatio = (float)exp / (float)reqExp;
                    Experience.Value = $"XP : {exp}/{reqExp}";
                    ProgressBarFillRate.Value = expRatio;
                })
                .AddTo(_disposable);
        }

        public void Dispose()
        {
            _disposable.Dispose();
        }
    }
}