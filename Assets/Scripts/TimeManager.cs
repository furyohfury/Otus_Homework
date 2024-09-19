using System;
using Cysharp.Threading.Tasks;
using Newtonsoft.Json;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

namespace RealTime
{
	public sealed class TimeManager : MonoBehaviour
	{
		[SerializeField]
		private TMP_Text _time;

		private const string ENTER_QUIT_TIME_PREFS = "ENTER_QUIT_TIME_PREFS";
		private const string SERVER_PATH = "https://timeapi.io/api/time/current/zone?timeZone=Europe%2FMoscow";

		private async void Awake()
		{
			var time = await GetServerTime();
			_time.text = time.ToString();
		}

		private async UniTask<DateTime> GetServerTime()
		{
			var request = UnityWebRequest.Get(SERVER_PATH);
			await request.SendWebRequest();
			if (request.result == UnityWebRequest.Result.Success)
			{
				var dateJson = request.downloadHandler.text;
				var date = JsonConvert.DeserializeObject<ServerTimeData>(dateJson);
				return DateTime.Parse(date.dateTime);
			}
			return default;
		}

		private struct ServerTimeData
		{
			public string dateTime;
		}
	}
}