using System.Collections.Generic;
using UniRx;

namespace Lessons.Architecture.PM
{
    public interface ICharacterAllStatsPresenter : IPresenter
    {
        public IReadOnlyReactiveCollection<IStatPresenter> StatPresenters { get; }
    }
}