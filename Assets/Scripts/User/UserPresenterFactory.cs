using UniRx;
using UnityEngine;

namespace Lessons.Architecture.PM
{
    public sealed class UserPresenterFactory
    {
        private UserInfo _userInfo;

        public UserPresenterFactory(UserInfo userInfo)
        {
            _userInfo=userInfo;
        }

        public UserPresenter Create() => new UserPresenter(_userInfo);
    }
}