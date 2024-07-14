using UniRx;
using UnityEngine;

namespace Popup.UI.User
{
    public interface IUserPresenter : IPresenter
    {
        public ReactiveProperty<string> Name { get; }
        public ReactiveProperty<string> Description { get; }
        public ReactiveProperty<Sprite> Icon { get; }

        void Dispose();
    }
}