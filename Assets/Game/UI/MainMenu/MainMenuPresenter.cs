using System;
using Zenject;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

namespace UI
{
	public sealed class MainMenuPresenter : IInitializable, IDisposable
	{
		private readonly MainMenuView _view;
		private readonly SelectLeveMenuView _selectLevelMenuView;
		private readonly SettingsMenuView _settingsMenuView;

		[Inject]
		public MainMenuPresenter(SelectLeveMenuView selectLevelMenuView, MainMenuView view, SettingsMenuView settingsMenuView)
		{
			_selectLevelMenuView = selectLevelMenuView;
			_view = view;
			_settingsMenuView = settingsMenuView;
		}

		public void Initialize()
		{
			_view.OnContinueButtonClicked += OnContinueButtonClicked;
			_view.OnSelectLevelButtonClicked += OnSelectLevelButtonClicked;
			_view.OnSettingsButtonPressed += OnSettingsButtonClicked;
			_view.OnExitButtonClicked += OnExitButtonClicked;
		}

		private void OnContinueButtonClicked()
		{
		}

		private void OnSelectLevelButtonClicked()
		{
			_selectLevelMenuView.Show();
		}

		private void OnSettingsButtonClicked()
		{
			var viewGO = _settingsMenuView.gameObject;
			if (viewGO.activeInHierarchy == false)
			{
				viewGO.SetActive(true);
			}
		}

		private void OnExitButtonClicked()
		{
#if UNITY_EDITOR
			EditorApplication.isPlaying = false;
#else
			Application.Quit();
#endif
		}

		public void Dispose()
		{
			_view.OnContinueButtonClicked -= OnContinueButtonClicked;
			_view.OnSelectLevelButtonClicked -= OnSelectLevelButtonClicked;
			_view.OnSettingsButtonPressed -= OnSettingsButtonClicked;
			_view.OnExitButtonClicked -= OnExitButtonClicked;
		}
	}
}