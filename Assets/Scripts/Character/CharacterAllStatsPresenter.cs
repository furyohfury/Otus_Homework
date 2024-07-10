using System.Collections.Generic;
using System.Linq;
using UniRx;

namespace Lessons.Architecture.PM
{
    public sealed class CharacterAllStatsPresenter : ICharacterAllStatsPresenter
    {
        public List<IStatPresenter> StatPresenters { get; private set; } = new();
        public IReadOnlyReactiveCollection<string> Stats => _stats;
        private ReactiveCollection<string> _stats;
        
        private CompositeDisposable _disposable = new();

        public CharacterAllStatsPresenter(CharacterInfo charInfo)
        {
            _stats = new(charInfo.Stats.Select(stat => FormatStat(stat)));
            charInfo.Stats
                .ObserveAdd()
                .Subscribe(stat => _stats.Add(FormatStat(stat.Value)))
                .AddTo(_disposable);

            charInfo.Stats
                .ObserveRemove()
                .Subscribe(stat => _stats.Remove(FormatStat(stat.Value)))
                .AddTo(_disposable);
        }

        public string FormatStat(CharacterStat stat) => $"{stat.Name}: {stat.Value}";

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }
    }
}