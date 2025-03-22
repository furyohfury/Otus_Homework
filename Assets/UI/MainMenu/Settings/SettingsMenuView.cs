using Game;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI
{
	public sealed class SettingsMenuView : MonoBehaviour
	{
		public event UnityAction OnCloseButtonPressed
		{
			add => _closeButton.onClick.AddListener(value);
			remove => _closeButton.onClick.RemoveListener(value);
		}

		public event UnityAction OnKeyboardControlsButtonPressed
		{
			add => _keyboardControlsButton.onClick.AddListener(value);
			remove => _keyboardControlsButton.onClick.RemoveListener(value);
		}

		public event UnityAction OnGamepadControlsButtonPressed
		{
			add => _gamepadControlsButton.onClick.AddListener(value);
			remove => _gamepadControlsButton.onClick.RemoveListener(value);
		}

		[SerializeField]
		private Button _closeButton;

		[SerializeField]
		private Button _keyboardControlsButton;

		[SerializeField]
		private Button _gamepadControlsButton;

		[SerializeField]
		private RebindMenuView _keyboardRebindMenu;
		
		[SerializeField]
		private RebindMenuView _gamepadRebindMenu;

		[SerializeField]
		private GameObject[] _views;

		public void SetKeyboardViewActive(bool active) => _keyboardRebindMenu.gameObject.SetActive(active);
		
		public void SetGamepadViewActive(bool active) => _gamepadRebindMenu.gameObject.SetActive(active);

		public void HideAll()
		{
			for (int i = 0, count = _views.Length; i < count; i++)
			{
				_views[i].SetActive(false);
			}
		}
	}
}