using UniRx;

namespace Popup.UI.Character.Level
{
    public interface ILevelUpButtonPresenter
    {
        public ReactiveCommand LevelUpCommand { get; }
        public ReactiveProperty<bool> CanLevelUp { get; }
    }
}