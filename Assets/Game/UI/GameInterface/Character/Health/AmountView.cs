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

		[SerializeField]
		private Image _icon;

		[SerializeField] [PreviewField]
		private Sprite _sprite;

		public void SetText(string text)
		{
			_text.text = text;
		}

		public void SetIcon(Sprite sprite)
		{
			_icon.sprite = sprite;
		}

		public void SetTextActive(bool active)
		{
			_text.gameObject.SetActive(active);
		}

		public void SetIconActive(bool active)
		{
			_icon.gameObject.SetActive(active);
		}

		private void OnValidate()
		{
			if (_sprite != null)
			{
				_icon.sprite = _sprite;
			}
		}
	}
}