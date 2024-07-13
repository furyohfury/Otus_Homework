using UniRx;

namespace Lessons.Architecture.PM
{
    public sealed class CharacterAllStatsPresenter : ICharacterAllStatsPresenter
    {
        public IReadOnlyReactiveCollection<IStatPresenter> StatPresenters => _statPresenters; // todo if not gonna do realtime changing, switch to casual list
        private ReactiveCollection<IStatPresenter> _statPresenters = new();

        public CharacterAllStatsPresenter(CharacterInfo charInfo)
        {
            foreach (var stat in charInfo.Stats) //todo replace w/ factory? Not neccesary for now
            {
                var statPresenter = new CharacterStatPresenter(stat);
                _statPresenters.Add(statPresenter);
            }
        }

        public void Dispose()
        {
            // todo fix
        }
    }
}