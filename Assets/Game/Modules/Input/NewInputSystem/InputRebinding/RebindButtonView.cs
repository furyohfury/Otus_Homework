using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Game
{
	public sealed class RebindButtonView : MonoBehaviour
	{
		public event UnityAction OnKeyRebindButtonPressed
		{
			add => _keyRebindButton.onClick.AddListener(value);
			remove => _keyRebindButton.onClick.RemoveListener(value);
		}
		
		public event UnityAction OnResetButtonPressed
		{
			add => _resetButton.onClick.AddListener(value);
			remove => _resetButton.onClick.RemoveListener(value);
		}
		
		[SerializeField]
		private Button _keyRebindButton;
		[SerializeField]
		private TMP_Text _bindText;
		[SerializeField]
		private Button _resetButton;
		[SerializeField]
		private TMP_Text _inputActionName;

		public void SetInputActionName(string actionName) => _inputActionName.text = actionName;
		
		public void SetBindText(string bindText) => _bindText.text = bindText;
	}
}