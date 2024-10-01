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
		private StringBuilder _viewTime = new();
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

			_currentSession.EntryTime = await ServerTimeManager.GetServerTimeOrDefault();			
			_button.onClick.AddListener(Show);
		}

		public void Show()
		{			
			_canvas.SetActive(true);
			_button.onClick.RemoveListener(Show);
			_button.onClick.AddListener(Hide);
			ShowTimeTable().Forget();
		}

		private async UniTask ShowTimeTable()
		{
			_cancellationTokenSource = new();
			while(!_cancellationTokenSource.IsCancellationRequested)
			{
				_viewTime.Clear();
				_viewTime.AppendLine("Entry\tQuit\tDuration");
				_viewTime.AppendLine(_previousSessionsString);
				_currentSession.SessionDuration = DateTime.Now - _currentSession.EntryTime;
				_viewTime.AppendLine(FormatTime(_currentSession));
				_viewTimeText.text = _viewTime.ToString();
				await UniTask.Delay(TimeSpan.FromSeconds(1f));
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
			var quitTime = await ServerTimeManager.GetServerTimeOrDefault();
			_currentSession.QuitTime = quitTime;
			_currentSession.SessionDuration = quitTime != default 
					? quitTime.Subtract(_currentSession.EntryTime)
					: default;
			_previousSessions.Add(_currentSession);
			var serializedSessions = JsonConvert.SerializeObject(_previousSessions);
			PlayerPrefs.SetString(ENTER_QUIT_TIME_PREFS, serializedSessions);
		}

		private string FormatTime(EnterQuitTime enterQuitTime)
		{
			var entry = enterQuitTime.EntryTime != default 
			? enterQuitTime.EntryTime.ToString("dd/MM/yy HH:mm:ss", CultureInfo.InvariantCulture)
			: "Error";

			var quit = enterQuitTime.QuitTime != default 
			? enterQuitTime.QuitTime.ToString("dd/MM/yy HH:mm:ss", CultureInfo.InvariantCulture)
			: "Error";

			var duration = enterQuitTime.SessionDuration != default 
			? enterQuitTime.SessionDuration.ToString("hh\\.mm\\:ss")
			: "Error";

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
			public DateTime EntryTime;
			public DateTime QuitTime;
			public TimeSpan SessionDuration;
		}
	}
}