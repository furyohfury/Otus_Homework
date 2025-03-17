using System.Collections.Generic;
using UnityEngine;

namespace Game
{
	public sealed class RebindMenuView : MonoBehaviour
	{
		[SerializeField]
		private RebindButtonView _rebindButtonViewPrefab;
		[SerializeField]
		private Transform _container;

		public RebindButtonView CreateRebindView(string actionDisplayName, string bindText)
		{
			var view = Instantiate(_rebindButtonViewPrefab, _container);
			view.SetInputActionName(actionDisplayName);
			view.SetBindText(bindText);
			view.gameObject.name = $"Rebind{actionDisplayName}View";

			return view;
		}
	}
}