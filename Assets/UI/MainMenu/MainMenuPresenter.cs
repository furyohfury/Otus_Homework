using System;
using Zenject;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace UI
{
	public sealed class MainMenuPresenter : IInitializable, IDisposable
	{
		private readonly MainMenuView _view;
		private readonly SelectLeveMenuView _selectLevelMenuView;

		[Inject]
		public MainMenuPresenter(SelectLeveMenuView selectLevelMenuView, MainMenuView view)
		{
			_selectLevelMenuView = selectLevelMenuView;
			_view = view;
		}

		public void Initialize()
		{
			_view.OnContinueButtonClicked += OnContinueButtonClicked;
			_view.OnSelectLevelButtonClicked += OnSelectLevelButtonClicked;
			_view.OnExitButtonClicked += OnExitButtonClicked;
		}

		private void OnContinueButtonClicked()
		{
		}

		private void OnSelectLevelButtonClicked()
		{
			_selectLevelMenuView.Show();
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
		}
	}
}