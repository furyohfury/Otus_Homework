using System;
using Zenject;

namespace UI
{
	public sealed class SettingsMenuPresenter : IInitializable, IDisposable
	{
		private readonly SettingsMenuView _settingsMenuView;

		public SettingsMenuPresenter(SettingsMenuView settingsMenuView)
		{
			_settingsMenuView = settingsMenuView;
		}

		void IInitializable.Initialize()
		{
			_settingsMenuView.OnCloseButtonPressed += OnClose;
			_settingsMenuView.OnKeyboardControlsButtonPressed += OnKeyboardControlsControlsPressed;
			_settingsMenuView.OnGamepadControlsButtonPressed += OnGamepadControlsPressed;
		}

		private void OnClose()
		{
			_settingsMenuView.gameObject.SetActive(false);
		}

		private void OnKeyboardControlsControlsPressed()
		{
			_settingsMenuView.HideAll();
			_settingsMenuView.SetKeyboardViewActive(true);
		}

		private void OnGamepadControlsPressed()
		{
			_settingsMenuView.HideAll();
			_settingsMenuView.SetGamepadViewActive(true);
		}

		public void Dispose()
		{
			_settingsMenuView.OnCloseButtonPressed -= OnClose;
			_settingsMenuView.OnKeyboardControlsButtonPressed -= OnKeyboardControlsControlsPressed;
			_settingsMenuView.OnGamepadControlsButtonPressed -= OnGamepadControlsPressed;
		}
	}
}