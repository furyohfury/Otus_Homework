using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI
{
	public sealed class LoginUserView : MonoBehaviour
	{
		public event UnityAction OnConfirmClicked
		{
			add => _confirmButton.onClick.AddListener(value);
			remove => _confirmButton.onClick.RemoveListener(value);
		}

		public event UnityAction<string> OnUsernameInputChanged
		{
			add => _inputField.onValueChanged.AddListener(value);
			remove => _inputField.onValueChanged.RemoveListener(value);
		}
		
		public string UsernameFieldText => _inputField.text;

		[SerializeField]
		private Button _confirmButton;
		[SerializeField]
		private TMP_InputField _inputField;
	}
}