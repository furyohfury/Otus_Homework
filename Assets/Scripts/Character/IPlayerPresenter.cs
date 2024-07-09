namespace Lessons.Architecture.PM
{
    public interface IPlayerPresenter : IPresenter
    {
        public ReactiveProperty<int> Level {get;}
        public ReactiveProperty<string> Experience {get;}
        public ReactiveProperty<float> ProgressBarFillRate {get;}
    }
}