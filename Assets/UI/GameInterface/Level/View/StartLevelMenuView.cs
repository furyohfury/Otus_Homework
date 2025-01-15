using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI
{
	public sealed class StartLevelMenuView : MonoBehaviour
	{
		public event UnityAction OnPlayButtonClicked
		{
			add => _playButton.onClick.AddListener(value);
			remove => _playButton.onClick.RemoveListener(value);
		}
		public event UnityAction OnMainMenuButtonClicked
		{
			add => _mainMenuButton.onClick.AddListener(value);
			remove => _mainMenuButton.onClick.RemoveListener(value);
		}

		[SerializeField]
		private Button _playButton;
		[SerializeField]
		private Button _mainMenuButton;
		[SerializeField]
		private AmountView _leaderboard;
	}
}