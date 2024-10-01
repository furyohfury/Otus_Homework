using System;
using TMPro;
using UnityEngine;

namespace RealTime
{
	public class EnterExitTimeController : MonoBehaviour
	{
		private const string ENTER_QUIT_TIME_PREFS = "ENTER_QUIT_TIME_PREFS";
		
		[SerializeField]
		private GameObject _canvas;
		[SerializeField]
		private TMP_Text _viewTimeText;
		[SerializeField]
		private Button _button;

		private bool _active = false;
		private EnterQuitTime _previousSessions;
		private EnterQuitTime _currentSession = new();		
		private StringBuilder _viewTime = new();

		private async void Start()
		{
			if (PlayerPrefs.HasKey(ENTER_QUIT_TIME_PREFS))
			{
				var prevSessions = PlayerPrefs.GetString(ENTER_QUIT_TIME_PREFS);
				_previousSessions = JsonConvert.DeserializeObject<EnterQuitTime>(prevSessions);
			}

			_currentSession.EnterTime = await ServerTimeManager.GetServerTimeOrDefault();			
			_button.onClick.AddListener(Show);
		}

		public void Show()
		{
			_viewTime.Clear();
			_viewTime.Append("Entry/tQuit/tDuration");
			foreach (var enterQuitTime in _previousSessions)
			{
				_viewTime.Append(FormatTime(enterQuitTime));
			}
			_viewTime.Append(FormatTime(_currentSession));
			_viewTimeText.text = _viewTime.ToString();
			_canvas.SetActive(true);
			_button.onClick.RemoveListener(Show);
			_button.onClick.AddListener(Hide);
		}

		private void Hide()
		{
			_canvas.SetActive(false);
			_button.onClick.RemoveListener(Hide);
			_button.onClick.AddListener(Show);
		}

		private void OnApplicationQuit()
		{
			var quitTime = await ServerTimeManager.GetServerTimeOrDefault();
			_currentSession.QuitTime = quitTime;
			_currentSession.SessionDuration = quitTime != default 
					? quitTime.Subtract(_currentSession.EntryTime);
					: default;
			_previousSessions.Add(_currentSession);
			var serializedSessions = JsonConvert.SerializeObject(_previousSessions);
			PlayerPrefs.SetString(ENTER_QUIT_TIME_PREFS, serializedSessions);
		}

		private string FormatTime(EnterQuitTime enterQuitTime)
		{
			var entry = enterQuitTime.EnterTime != default 
			? EnterTime.ToString("G")
			: "Error";

			var quit = enterQuitTime.QuitTime != default 
			? QuitTime.ToString("G")
			: "Error";

			var duration = enterQuitTime.SessionDuration != default 
			? SessionDuration.ToString("G")
			: "Error";

			return $"{entry}/t{quit}/t{duration}";
		}

		private struct EnterQuitTime
		{
			public DateTime EnterTime;
			public DateTime QuitTime;
			public TimeSpan SessionDuration;
		}
	}
}