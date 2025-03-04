using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI
{
	public sealed class LevelMiniatureView : MonoBehaviour
	{
		public event UnityAction OnChooseLevelButtonClicked
		{
			add => _chooseLevelButton.onClick.AddListener(value);
			remove => _chooseLevelButton.onClick.RemoveListener(value);
		}

		public Image CupIcon
		{
			get => _cupIcon;
			set => _cupIcon = value;
		}

		public TMP_Text SceneName
		{
			get => _sceneName;
			set => _sceneName = value;
		}

		public TMP_Text BestTime
		{
			get => _bestTime;
			set => _bestTime = value;
		}
		public Image Icon
		{
			get => _icon;
			set => _icon = value;
		}

		[SerializeField]
		private Button _chooseLevelButton;
		[SerializeField]
		private Image _icon;
		[SerializeField]
		private TMP_Text _sceneName;
		[SerializeField]
		private Image _cupIcon;
		[SerializeField]
		private TMP_Text _bestTime;
	}
}