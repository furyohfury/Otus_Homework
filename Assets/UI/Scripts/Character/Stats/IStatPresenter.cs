using UniRx;

namespace Lessons.Architecture.PM
{
    public interface IStatPresenter : IPresenter
    {
        public ReactiveProperty<string> Stat { get; }
        void Dispose();
    }
}