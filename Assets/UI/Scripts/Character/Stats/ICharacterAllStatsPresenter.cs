using System.Collections.Generic;

namespace Lessons.Architecture.PM
{
    public interface ICharacterAllStatsPresenter : IPresenter
    {
        public IReadOnlyList<IStatPresenter> StatPresenters { get; }
    }
}