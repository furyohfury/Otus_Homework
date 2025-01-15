using System;
using Game;
using Zenject;

namespace UI
{
	public sealed class StartLevelMenuPresenter : IInitializable, IDisposable
	{
		private readonly StartLevelMenuView _view;
		private readonly LevelManager _levelManager;

		[Inject]
		public StartLevelMenuPresenter(StartLevelMenuView view, LevelManager levelManager)
		{
			_view = view;
			_levelManager = levelManager;
		}

		public void Initialize()
		{
			_view.OnPlayButtonClicked += OnPlayButtonClicked;
			_view.OnMainMenuButtonClicked += OnMainMenuButtonClicked;
			_levelManager.OnLevelReset += OnLevelReset;
		}

		private void OnPlayButtonClicked()
		{
			_view.gameObject.SetActive(false);
			_levelManager.StartLevel();
		}

		private void OnMainMenuButtonClicked()
		{
			// TODO common logic
		}

		private void OnLevelReset()
		{
			_view.gameObject.SetActive(true);
		}

		public void Dispose()
		{
			_view.OnPlayButtonClicked -= OnPlayButtonClicked;
			_view.OnMainMenuButtonClicked -= OnMainMenuButtonClicked;
		}
	}
}