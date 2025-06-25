using System;
using PlayFabSystem;
using Zenject;

namespace UI
{
	public sealed class LoginUserPresenter : IInitializable, IDisposable
	{
		private readonly LoginUserView _loginUserView;
		private const int NUMBER_OF_TRIES = 3;

		public LoginUserPresenter(LoginUserView loginUserView)
		{
			_loginUserView = loginUserView;
		}

		public void Initialize()
		{
			if (PlayfabManager.AttemptedLogin)
			{
				_loginUserView.gameObject.SetActive(false);
			}
			_loginUserView.OnConfirmClicked += OnConfirmClicked;
			_loginUserView.OnUsernameInputChanged += OnUsernameInputChanged;
		}

		private async void OnConfirmClicked()
		{
			_loginUserView.OnConfirmClicked -= OnConfirmClicked;
			var usernameFieldText = _loginUserView.UsernameFieldText;
			if (string.IsNullOrEmpty(usernameFieldText))
			{
				return;
			}

			// TODO censoreship
			for (var i = 0; i < NUMBER_OF_TRIES; i++)
			{
				try
				{
					await PlayfabManager.Login(usernameFieldText);
					ContinueLogged();
					return;
				}
				catch
				{
				}
			}

			ContinueUnlogged();
		}

		private void ContinueLogged()
		{
		}

		private void ContinueUnlogged()
		{
		}

		private void OnUsernameInputChanged(string username)
		{
		}

		public void Dispose()
		{
		}
	}
}