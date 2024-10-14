﻿using System;
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

			try
			{
				_currentSession.EntryTime = await ServerTimeManager.GetServerTimeByIPAsync();
			}
			catch (Exception e)
			{
				_currentSession.EntryTime = null;
				Debug.LogError(e.Message);
			}
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
			_cancellationTokenSource = new CancellationTokenSource();
			while (!_cancellationTokenSource.IsCancellationRequested)
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
			try
			{
				var quitTime = await ServerTimeManager.GetServerTimeByIPAsync();
				_currentSession.QuitTime = quitTime;
				if (_currentSession.EntryTime.HasValue)
				{
					_currentSession.SessionDuration = quitTime.Subtract(_currentSession.EntryTime.Value);
				}
			}
			catch (Exception e)
			{
				Debug.LogError(e.Message);
				throw;
			}
			finally
			{
				_previousSessions.Add(_currentSession);
				var serializedSessions = JsonConvert.SerializeObject(_previousSessions);
				PlayerPrefs.SetString(ENTER_QUIT_TIME_PREFS, serializedSessions);
			}
		}

		private string FormatTime(EnterQuitTime enterQuitTime)
		{
			var entry = enterQuitTime.EntryTime.HasValue
				? enterQuitTime.EntryTime.Value.ToString("dd/MM/yy HH:mm:ss", CultureInfo.InvariantCulture)
				: "No data";

			var quit = enterQuitTime.QuitTime.HasValue
				? enterQuitTime.QuitTime.Value.ToString("dd/MM/yy HH:mm:ss", CultureInfo.InvariantCulture)
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