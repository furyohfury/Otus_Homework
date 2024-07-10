using UniRx;

namespace Lessons.Architecture.PM
{
    public sealed class CharacterAllStatsPresenter : ICharacterAllStatsPresenter
    {
        public IReadOnlyReactiveCollection<string> Stats { get; private set;} => _stats;
        private ReactiveCollection<string> _stats {get; private set; } = new();

        private List<ICharacterStatPresenter> _statPresenters = new();

        public CharacterAllStatsPresenter(CharacterInfo charInfo)
        {
            charInfo.Stats
                .Subscribe()
        }

        
    }
}