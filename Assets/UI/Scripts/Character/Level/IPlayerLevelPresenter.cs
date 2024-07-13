using UniRx;

namespace Lessons.Architecture.PM
{
    public interface IPlayerLevelPresenter : IPresenter
    {
        public ReactiveProperty<string> Level { get; }
        public ReactiveProperty<string> Experience { get; }
        public ReactiveProperty<float> ProgressBarFillRate { get; }
    }
}