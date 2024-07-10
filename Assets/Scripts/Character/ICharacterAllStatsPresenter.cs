using System.Collections.Generic;
using UniRx;

namespace Lessons.Architecture.PM
{
    public interface ICharacterAllStatsPresenter : IPresenter
    {
        public IReadOnlyReactiveCollection<string> Stats { get; }
        public List<IStatPresenter> StatPresenters { get; }
    }
}