using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI
{
	public sealed class PauseMenuView : MonoBehaviour
	{
		public event UnityAction OnResumeButtonClicked
		{
			add => _resumeButton.onClick.AddListener(value);
			remove => _resumeButton.onClick.RemoveListener(value);
		}
		public event UnityAction OnResetButtonClicked
		{
			add => _resetButton.onClick.AddListener(value);
			remove => _resetButton.onClick.RemoveListener(value);
		}
		public event UnityAction OnMainMenuButtonClicked
		{
			add => _mainMenuButton.onClick.AddListener(value);
			remove => _mainMenuButton.onClick.RemoveListener(value);
		}

		[SerializeField]
		private Button _resumeButton;
		[SerializeField]
		private Button _resetButton;
		[SerializeField]
		private Button _mainMenuButton;
	}
}