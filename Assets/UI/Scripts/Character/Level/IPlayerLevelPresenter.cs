using UniRx;

namespace Lessons.Architecture.PM
{
    public interface IPlayerLevelPresenter : IPresenter
    {
        public ReactiveProperty<string> Level { get; }       

        void Dispose();
    }
}