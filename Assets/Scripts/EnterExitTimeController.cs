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

		private bool _active = false;
		private List<EnterQuitTime> _previousSessions = new();
		private EnterQuitTime _currentSession;
		private readonly StringBuilder _viewTime = new();
		private string _previousSessionsString;

		private CancellationTokenSource _cancellationTokenSource = new();

		private async void Start()
		{
			if (PlayerPrefs.HasKey(ENTER_QUIT_TIME_PREFS))
			{
				var prevSessions = PlayerPrefs.GetString(ENTER_QUIT_TIME_PREFS);
				_previousSessions = JsonConvert.DeserializeObject<List<EnterQuitTime>>(prevSessions);

				foreach (var enterQuitTime in _previousSessions)
				{
					_viewTime.AppendLine(FormatTime(enterQuitTime));
				}

				_previousSessionsString = _viewTime.ToString();
			}

			_button.onClick.AddListener(Show);

			var serverTimeRequest = await ServerTimeManager.TryGetServerTimeAsync();
			if (serverTimeRequest.successful)
			{
				_currentSession.EntryTime = serverTimeRequest.serverTime;
			}
			else
			{
				Debug.LogError("Cant get server time");
			}
		}

		public async void Show()
		{
			_canvas.SetActive(true);
			_button.onClick.RemoveListener(Show);
			_button.onClick.AddListener(Hide);
			ShowTimeTable().Forget();
		}

		private async UniTask ShowTimeTable()
		{
			DateTime currentTime = default;
			TimeSpan timeBeforeOpening = default;

			var serverTimeRequest = await ServerTimeManager.TryGetServerTimeAsync();
			if (serverTimeRequest.successful)
			{
				currentTime = serverTimeRequest.serverTime;
			}
			else
			{
				Debug.LogError("Cant get server time");
			}

			var canCountDuration = currentTime != default && _currentSession.EntryTime.HasValue;
			if (canCountDuration)
			{
				timeBeforeOpening = currentTime - _currentSession.EntryTime.Value;
			}

			int secondsPassed = 0;

			_cancellationTokenSource = new CancellationTokenSource();
			while (!_cancellationTokenSource.IsCancellationRequested)
			{
				_viewTime.Clear();
				_viewTime.AppendLine("Entry\tQuit\tDuration");
				_viewTime.AppendLine(_previousSessionsString);
				if (canCountDuration)
				{
					_currentSession.SessionDuration = timeBeforeOpening.Add(TimeSpan.FromSeconds(secondsPassed));
				}

				_viewTime.AppendLine(FormatTime(_currentSession));
				_viewTimeText.text = _viewTime.ToString();
				await UniTask.Delay(TimeSpan.FromSeconds(1f));
				secondsPassed++;
			}
		}

		private void Hide()
		{
			_canvas.SetActive(false);
			_button.onClick.RemoveListener(Hide);
			_button.onClick.AddListener(Show);
			_cancellationTokenSource.Cancel();
		}

		private async void OnApplicationQuit()
		{
			var (successful, serverTime) = await ServerTimeManager.TryGetServerTimeAsync();
			if (successful)
			{
				_currentSession.QuitTime = serverTime;
				if (_currentSession.EntryTime.HasValue)
				{
					_currentSession.SessionDuration = serverTime.Subtract(_currentSession.EntryTime.Value);
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