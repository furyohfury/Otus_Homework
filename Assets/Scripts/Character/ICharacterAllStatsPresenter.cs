using UniRx;

namespace Lessons.Architecture.PM
{
    public interface ICharacterAllStatsPresenter : IPresenter
    {
        public IReadOnlyReactiveCollection<string> Stats { get; }
    }
}