using Popup.GameData;
using UniRx;

namespace Popup.UI.Character.Level
{
    public sealed class PlayerLevelPresenter : IPlayerLevelPresenter
    {
        public ReactiveProperty<string> Level { get; private set; } = new();

        private readonly PlayerLevel _playerLevel;
        private readonly CompositeDisposable _disposable = new();

        public PlayerLevelPresenter(PlayerLevel playerLevel)
        {
            _playerLevel = playerLevel;

            _playerLevel.CurrentLevel
                .Subscribe(level => Level.Value = level.ToString())
                .AddTo(_disposable);
        }

        public void Dispose()
        {
            _disposable.Clear();
        }
    }
}