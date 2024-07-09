﻿using UniRx;
using UnityEngine;

namespace Lessons.Architecture.PM
{
    public sealed class UserPresenter : IUserPresenter
    {
        public ReactiveProperty<string> Name { get; } = new();
        public ReactiveProperty<string> Description { get; } = new();
        public ReactiveProperty<Sprite> Icon { get; } = new();

        private CompositeDisposable _disposable = new();

        public UserPresenter(UserInfo userInfo)
        {
            // userInfo.Name.Value.Subscribe todo
        }

        public void Dispose()
        {
            _disposable.Clear();
        }
    }
}