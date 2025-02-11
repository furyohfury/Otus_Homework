using UnityEngine;
using Zenject;

namespace UI
{
	public sealed class LevelMiniatureViewFactory
	{
		private readonly LevelMiniatureView _viewPrefab;

		[Inject]
		public LevelMiniatureViewFactory(LevelMiniatureView viewPrefab)
		{
			_viewPrefab = viewPrefab;
		}

		public LevelMiniatureView Create(Transform container)
		{
			var view = Object.Instantiate(_viewPrefab, container);
			return view;
		}
	}
}