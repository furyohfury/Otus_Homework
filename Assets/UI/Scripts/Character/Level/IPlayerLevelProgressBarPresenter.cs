using UniRx;

namespace Lessons.Architecture.PM
{
    public interface IPlayerLevelProgressBarPresenter : IPresenter
    {
        public ReactiveProperty<string> Experience { get; }
        public ReactiveProperty<float> ProgressBarFillRate { get; }

        void Dispose();
    }
}