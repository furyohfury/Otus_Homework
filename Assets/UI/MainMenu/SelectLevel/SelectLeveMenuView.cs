using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI
{
	public sealed class SelectLeveMenuView : MonoBehaviour // TODO hueta, peredelat. Ponyat kto chto doljen spavnit
	{
		[SerializeField]
		private Transform _container;
		private SelectLevelMenuPresenter _presenter;
		private LevelMiniatureViewFactory _levelMiniatureViewFactory;
		private List<LevelMiniatureView> _views = new();

		[SerializeField]
		private Button _closeButton;

		[Inject]
		private void Construct(SelectLevelMenuPresenter presenter, LevelMiniatureViewFactory levelMiniatureViewFactory)
		{
			_presenter = presenter;
			_levelMiniatureViewFactory = levelMiniatureViewFactory;
		}

		public void Show()
		{
			if (gameObject.activeInHierarchy)
			{
				return;
			}

			_closeButton.onClick.AddListener(Hide);
			_presenter.OnViewShown();
			SpawnLevelsViews();
			gameObject.SetActive(true);
		}

		private void SpawnLevelsViews()
		{
			for (int i = 0, count = _presenter.Levels.Length; i < count; i++)
			{
				var level = _presenter.Levels[i];
				var miniatureView = _levelMiniatureViewFactory.Create(_container);
				_views.Add(miniatureView);
				_presenter.OnLevelMiniatureViewCreated(miniatureView, level);
			}
		}

		private void Hide()
		{
			_closeButton.onClick.RemoveListener(Hide);
			gameObject.SetActive(false);
			for (int i = 0, count = _views.Count; i < count; i++)
			{
				Destroy(_views[i].gameObject);
				_views.Remove(_views[i]);
			}
		}
	}
}