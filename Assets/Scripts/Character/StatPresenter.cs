using UniRx;

namespace Lessons.Architecture.PM
{
    public sealed class StatPresenter : IStatPresenter
    {
        public ReactiveProperty<string> Stat { get; private set; } = new();

        private CharacterStat _characterStat;
        private CompositeDisposable _disposable = new();

        public StatPresenter(CharacterStat stat)
        {
            _characterStat = stat;
            _characterStat.Name
                .Subscribe(_ => Stat.Value = $"{_characterStat.Name.Value} : {_characterStat.Value.Value}")
                .AddTo(_disposable);

            _characterStat.Value
                .Subscribe(_ => Stat.Value = $"{_characterStat.Name.Value} : {_characterStat.Value.Value}")
                .AddTo(_disposable);
        }

        public void Dispose()
        {
            _disposable.Clear();
        }
    }
}