using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI
{
	public sealed class GameOverMenuView : MonoBehaviour
	{
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
		private Button _resetButton;
		[SerializeField]
		private Button _mainMenuButton;
	}
}