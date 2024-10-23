using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading;
using Cysharp.Threading.Tasks;
using Newtonsoft.Json;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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

		private List<EnterQuitTime> _previousSessions = new();
		private EnterQuitTime _currentSession;
		private string _previousSessionsString;

		private CancellationTokenSource _cancellationTokenSource = new();

		private async void Start()
		{
			if (PlayerPrefs.HasKey(ENTER_QUIT_TIME_PREFS))
			{
				var prevSessions = PlayerPrefs.GetString(ENTER_QUIT_TIME_PREFS);
				_previousSessions = JsonConvert.DeserializeObject<List<EnterQuitTime>>(prevSessions);

				var previousSessionsString = new StringBuilder();
				foreach (var enterQuitTime in _previousSessions)
				{
					previousSessionsString.AppendLine(FormatTime(enterQuitTime));
				}

				_previousSessionsString = previousSessionsString.ToString();
			}

			_button.onClick.AddListener(OnShowButtonClick);

			if (!ServerTimeManager.Instance.Initialized)
			{
				await UniTask.WaitUntil(() => ServerTimeManager.Instance.Initialized);
			}
			
			// Setup entry time
			if (ServerTimeManager.Instance.TryGetCurrentTime(out DateTime currentTime))
			{
				_currentSession.EntryTime = currentTime;
			}
		}

		private void OnShowButtonClick()
		{
			if (_canvas.gameObject.activeSelf)
			{
				_canvas.SetActive(false);
				_cancellationTokenSource.Cancel();
			}
			else
			{
				_canvas.SetActive(true);
				ShowTimeTable().Forget();
			}
		}

		private async UniTask ShowTimeTable()
		{
			_cancellationTokenSource = new CancellationTokenSource();
			while (!_cancellationTokenSource.IsCancellationRequested)
			{
				if (_currentSession.EntryTime.HasValue &&
				    ServerTimeManager.Instance.TryGetCurrentTime(out DateTime currentTime))
				{
					_currentSession.SessionDuration = currentTime - _currentSession.EntryTime.Value;
				}
				else
				{
					_currentSession.SessionDuration = null;
				}

				var currentSessionString = FormatTime(_currentSession);
				_viewTimeText.text = string.Concat(_previousSessionsString, currentSessionString);
				await UniTask.Delay(TimeSpan.FromSeconds(1f));
			}
		}		

		private void SaveSessionData()
		{
			if (ServerTimeManager.Instance.TryGetCurrentTime(out DateTime currentTime))
			{
				_currentSession.QuitTime = currentTime;
				if (_currentSession.EntryTime.HasValue)
				{
					_currentSession.SessionDuration = currentTime.Subtract(_currentSession.EntryTime.Value);
				}
			}

			_previousSessions.Add(_currentSession);
			var serializedSessions = JsonConvert.SerializeObject(_previousSessions);
			PlayerPrefs.SetString(ENTER_QUIT_TIME_PREFS, serializedSessions);
		}

		private string FormatTime(EnterQuitTime enterQuitTime)
		{
			var entry = enterQuitTime.EntryTime.HasValue
				? enterQuitTime.EntryTime.Value.ToString("dd/MM/yy HH:mm:ss", CultureInfo.CurrentCulture)
				: "No data";

			var quit = enterQuitTime.QuitTime.HasValue
				? enterQuitTime.QuitTime.Value.ToString("dd/MM/yy HH:mm:ss")
				: "No data";

			var duration = enterQuitTime.SessionDuration.HasValue
				? enterQuitTime.SessionDuration.Value.ToString("hh\\:mm\\:ss")
				: "No data";

			return $"{entry}\t{quit}\t{duration}";
		}

		private void OnApplicationQuit()
		{
			SaveSessionData();
		}

#if UNITY_EDITOR
		[Button]
		public void ClearPrefs()
		{
			PlayerPrefs.DeleteAll();
		}
#endif

		private struct EnterQuitTime
		{
			public DateTime? EntryTime;
			public DateTime? QuitTime;
			public TimeSpan? SessionDuration;
		}
	}
}