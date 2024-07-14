using System.Collections.Generic;

namespace Popup.UI.Character.Stats
{
    public interface ICharacterAllStatsPresenter : IPresenter
    {
        public IReadOnlyList<IStatPresenter> StatPresenters { get; }
    }
}