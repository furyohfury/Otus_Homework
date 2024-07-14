using System.Collections.Generic;

namespace Popup.UI.Character.Stats
{
    public sealed class CharacterAllStatsPresenter : ICharacterAllStatsPresenter
    {
        public IReadOnlyList<IStatPresenter> StatPresenters => _statPresenters;
        private readonly IStatPresenter[] _statPresenters;

        private CharacterStatsPresenterFactory _characterStatPresenterFactory;

        public CharacterAllStatsPresenter(CharacterStatsPresenterFactory characterStatPresenterFactory)
        {
            _characterStatPresenterFactory = characterStatPresenterFactory;
            _statPresenters = _characterStatPresenterFactory.CreateStatPresenters();
        }
    }
}