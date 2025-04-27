using UnityEngine;
using UnityEngine.UI;

namespace UI
{
	public sealed class AbilityCardView : MonoBehaviour
	{
		public Image Icon => _icon;
		
		[SerializeField]
		private Image _icon;
		[SerializeField]
		private LayoutElement _layoutElement;

		public void SetIcon(Sprite sprite)
		{
			Icon.sprite = sprite;
		}

		public void IgnoreLayout(bool ignore)
		{
			_layoutElement.ignoreLayout = ignore;
		}
	}
}