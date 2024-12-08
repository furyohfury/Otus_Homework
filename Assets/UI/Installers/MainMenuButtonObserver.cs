using System;
using Game;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

namespace UI
{
	public sealed class MainMenuButtonObserver : IInitializable, IDisposable
	{
		private readonly Button _mainMenuButton;

		[Inject]
		public MainMenuButtonObserver(Button mainMenuButton)
		{
			_mainMenuButton = mainMenuButton;
		}

		public void Initialize()
		{
			_mainMenuButton.onClick.AddListener(OnMainMenuButtonPressed);
		}

		private void OnMainMenuButtonPressed()
		{
			SceneManager.LoadScene(SceneNames.MAIN_MENU_SCENE);
		}

		public void Dispose()
		{
			_mainMenuButton.onClick.RemoveListener(OnMainMenuButtonPressed);
		}
	}
}