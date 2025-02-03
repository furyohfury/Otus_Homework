using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI
{
	public sealed class FinishLevelMenuView : MonoBehaviour
	{
		public event UnityAction OnRetryButtonClicked
		{
			add => _retryButton.onClick.AddListener(value);
			remove => _retryButton.onClick.RemoveListener(value);
		}
		public event UnityAction OnMainMenuButtonClicked
		{
			add => _mainMenuButton.onClick.AddListener(value);
			remove => _mainMenuButton.onClick.RemoveListener(value);
		}

		public AmountView LeaderboardView => _leaderboard;

		[SerializeField]
		private Button _retryButton;
		[SerializeField]
		private Button _mainMenuButton;
		[SerializeField]
		private AmountView _leaderboard;
	}
}
