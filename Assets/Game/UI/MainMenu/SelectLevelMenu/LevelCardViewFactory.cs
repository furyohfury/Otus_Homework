using UnityEngine;
using Zenject;

namespace UI
{
	public sealed class LevelCardViewFactory
	{
		private readonly LevelCardView _viewPrefab;

		[Inject]
		public LevelCardViewFactory(LevelCardView viewPrefab)
		{
			_viewPrefab = viewPrefab;
		}

		public LevelCardView Create(Transform container)
		{
			var view = Object.Instantiate(_viewPrefab, container);
			return view;
		}
	}
}