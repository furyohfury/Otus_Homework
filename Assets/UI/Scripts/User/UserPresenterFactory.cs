using Popup.GameData;

namespace Popup.UI.User
{
    public sealed class UserPresenterFactory
    {
        private readonly UserInfo _userInfo;

        public UserPresenterFactory(UserInfo userInfo)
        {
            _userInfo = userInfo;
        }

        public UserPresenter Create() => new UserPresenter(_userInfo);
    }
}