using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI
{
	public sealed class MainMenuView : MonoBehaviour
	{
		public event UnityAction OnContinueButtonClicked
		{
			add => _continueButton.onClick.AddListener(value);
			remove => _continueButton.onClick.RemoveListener(value);
		}

		public event UnityAction OnSelectLevelButtonClicked
		{
			add => _selectLevelButton.onClick.AddListener(value);
			remove => _selectLevelButton.onClick.RemoveListener(value);
		}

		public event UnityAction OnExitButtonClicked
		{
			add => _exitButton.onClick.AddListener(value);
			remove => _exitButton.onClick.RemoveListener(value);
		}

		[SerializeField]
		private Button _continueButton;
		[SerializeField]
		private Button _selectLevelButton;
		[SerializeField]
		private Button _exitButton;
	}
}