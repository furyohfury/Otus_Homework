using System.Collections.Generic;
using Game;
using Sirenix.OdinInspector;
using UnityEngine;

namespace UI
{
	public sealed class CupsListView : SerializedMonoBehaviour // TODO put into finishlevelview or not? Then presenter too
	{
		[SerializeField]
		private Dictionary<Cups, AmountView> _cupsView;

		public void SetCupViewActive(Cups cup, bool active) => _cupsView[cup].SetIconActive(active);

		public void SetCupTimeText(Cups cup, string text)
		{
			var view = _cupsView[cup];
			view.SetText(text);
		}

		public void HideAll()
		{
			foreach (var cup in _cupsView.Keys)		
			{
				SetCupViewActive(cup, false);
			}
		}
	}
}