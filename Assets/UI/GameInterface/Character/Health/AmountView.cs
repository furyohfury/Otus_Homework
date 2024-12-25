using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
	public sealed class AmountView : MonoBehaviour
	{
		[SerializeField]
		private TMP_Text _text;

		[SerializeField][PreviewField]
		private Image _icon;

		public void SetText(string text) => _text.text = text;

		public void SetIcon(Sprite sprite) => _icon.sprite = sprite;
	}
}