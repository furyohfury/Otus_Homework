namespace Lessons.Architecture.PM
{
    public sealed class StatPresenter : IStatPresenter
    {
        public ReactiveProperty<string> Stat { get; private set;} = new();

        private CharacterStat _characterStat;
        private CompositeDisposable _disposable = new();

        public StatPresenter(CharacterStat stat)
        {
            var namestream = _characterStat.Name;
            var valuestream = _characterStat.Value;
            var statstream = _nameStream.Merge(valuestream);
            statstream
                .Subscribe(_ => Stat = $"{_characterStat.Name} : {_characterStat.Value}") //todo whats the input data from merge?
                .AddTo(_disposable);
        }

        public void Dispose()
        {
            _disposable.Clear();
        }
    }
}