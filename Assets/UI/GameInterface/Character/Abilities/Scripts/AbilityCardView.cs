using UnityEngine;
using UnityEngine.UI;

namespace UI
{
	public sealed class AbilityCardView : MonoBehaviour
	{
		[SerializeField]
		private Image _icon;

		public void SetIcon(Sprite sprite)
		{
			_icon.sprite = sprite;
		}
	}
}