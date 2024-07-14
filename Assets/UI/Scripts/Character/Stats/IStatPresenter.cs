using UniRx;

namespace Popup.UI.Character.Stats
{
    public interface IStatPresenter : IPresenter
    {
        public ReactiveProperty<string> Stat { get; }
        void Dispose();
    }
}