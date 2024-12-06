using TMPro;
using UnityEngine;

namespace UI
{
	public sealed class SingleTextFieldView : MonoBehaviour
	{
		[SerializeField]
		private TMP_Text _text;

		public void SetText(string text)
		{
			_text.text = text;
		}
	}
}