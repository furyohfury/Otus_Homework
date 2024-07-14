using UniRx;

namespace Popup.UI.Character.Level
{
    public interface IPlayerLevelProgressBarPresenter : IPresenter
    {
        public ReactiveProperty<string> Experience { get; }
        public ReactiveProperty<float> ProgressBarFillRate { get; }

        void Dispose();
    }
}