using System;
using TMPro;
using UnityEngine;

namespace RealTime
{
	public class EnterExitTimeController : MonoBehaviour
	{
		private const string ENTER_QUIT_TIME_PREFS = "ENTER_QUIT_TIME_PREFS";
		private TMP_Text _view;
		private bool _active = false;
		private string _previousSessions;
		private DateTime _entryTime;
		private TimeManager _timeManager;

		private async void Start()
		{
			if (PlayerPrefs.HasKey(ENTER_QUIT_TIME_PREFS))
			{
				_previousSessions = PlayerPrefs.GetString(ENTER_QUIT_TIME_PREFS);
			}

			_entryTime = await _timeManager.GetServerTimeOrDefault();
		}

		public void Show()
		{
			string text;
		}

		private void OnApplicationQuit()
		{
		}

		private struct EnterQuitTime
		{
			public DateTime EnterTime;
			public DateTime QuitTime;
			public TimeSpan SessionDuration;
		}
	}
}