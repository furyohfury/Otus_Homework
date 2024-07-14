using System.Collections.Generic;

namespace Lessons.Architecture.PM
{
    public sealed class CharacterAllStatsPresenter : ICharacterAllStatsPresenter
    {
        public IReadOnlyList<IStatPresenter> StatPresenters => _statPresenters; // todo if not gonna do realtime changing, switch to casual list
        private readonly IStatPresenter[] _statPresenters;

        private CharacterStatsPresenterFactory _characterStatPresenterFactory;

        public CharacterAllStatsPresenter(CharacterStatsPresenterFactory characterStatPresenterFactory)
        {
            //foreach (var stat in charInfo.Stats) //todo replace w/ factory? Not neccesary for now
            //{
            //    var statPresenter = new CharacterStatPresenter(stat);
            //    _statPresenters.Add(statPresenter);
            //}
            _characterStatPresenterFactory = characterStatPresenterFactory;
            _statPresenters = _characterStatPresenterFactory.CreateStatPresenters();
        }
    }
}