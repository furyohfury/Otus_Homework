using UniRx;
using UnityEngine;

namespace Lessons.Architecture.PM
{
    public sealed class UserPresenter : IUserPresenter
    {
        public ReactiveProperty<string> Name { get; } = new();
        public ReactiveProperty<string> Description { get; } = new();
        public ReactiveProperty<Sprite> Icon { get; } = new();

        private readonly CompositeDisposable _disposable = new();

        public UserPresenter(UserInfo userInfo)
        {
            userInfo.Name
                .Subscribe(name => Name.Value = name)
                .AddTo(_disposable);

            userInfo.Description
                .Subscribe(desc => Description.Value = desc)
                .AddTo(_disposable);

            userInfo.Icon
                .Subscribe(icon => Icon.Value = icon)
                .AddTo(_disposable);
        }

        public void Dispose()
        {
            _disposable.Clear();
        }
    }
}