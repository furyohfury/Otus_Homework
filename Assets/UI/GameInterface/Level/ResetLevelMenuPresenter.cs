using System;
using Game;
using Zenject;

namespace UI
{
	public sealed class ResetLevelMenuPresenter : IInitializable, IDisposable
	{
		private readonly ResetLevelMenuView _view;
		private readonly LevelManager _levelManager;

		[Inject]
		public ResetLevelMenuPresenter(ResetLevelMenuView view, LevelManager levelManager)
		{
			_view = view;
			_levelManager = levelManager;
		}

		public void Initialize()
		{
			_view.OnResetButtonClicked += OnResetButtonClicked;
			_view.OnMainMenuButtonClicked += OnMainMenuButtonClicked;
		}

		private void OnResetButtonClicked()
		{
			_view.gameObject.SetActive(false);
			_levelManager.ResetLevel();
		}

		private void OnMainMenuButtonClicked()
		{
			// TODO common logic
		}

		public void Dispose()
		{
			_view.OnResetButtonClicked -= OnResetButtonClicked;
			_view.OnMainMenuButtonClicked -= OnMainMenuButtonClicked;
		}
	}
}