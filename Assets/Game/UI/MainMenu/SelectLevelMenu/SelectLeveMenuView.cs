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
		private LevelCardViewFactory _levelCardViewFactory;
		private readonly List<LevelCardView> _views = new();

		[SerializeField]
		private Button _closeButton;

		[Inject]
		private void Construct(SelectLevelMenuPresenter presenter, LevelCardViewFactory levelCardViewFactory)
		{
			_presenter = presenter;
			_levelCardViewFactory = levelCardViewFactory;
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
			var levels = _presenter.GetLevels();
			for (int i = 0, count = levels.Length; i < count; i++)
			{
				var level = levels[i];
				var miniatureView = _levelCardViewFactory.Create(_container);
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
				var view = _views[i];
				Destroy(view.gameObject);
			}

			_views.Clear();
		}
	}
}