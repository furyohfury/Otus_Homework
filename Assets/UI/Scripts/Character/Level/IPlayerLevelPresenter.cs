using UniRx;

namespace Popup.UI.Character.Level
{
    public interface IPlayerLevelPresenter : IPresenter
    {
        public ReactiveProperty<string> Level { get; }

        void Dispose();
    }
}