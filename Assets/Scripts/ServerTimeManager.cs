using System;
using System.Net;
using Cysharp.Threading.Tasks;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;

namespace RealTime
{
	public static class ServerTimeManager : MonoBehaviour
	{
		public static ServerTimeManager Instance;
		
		private const string SERVER_PATH = "https://timeapi.io/api/time/current/zone?timeZone=Etc/UTC";
		private 
		private readonly int _numberOfConnectionRetries = 3;
		private DateTime _serverTime;
		private TimeSpan _delta;

		private async UniTaskVoid Awake()
		{
			if (Instance == null)
			{
				Instance = this;
			}
			else
			{
				Destroy(this);
			}
			var serverTimeRequest = await TryGetServerTimeAsync();
			if (serverTimeRequest.successful)
			{
				_serverTime = serverTimeRequest.serverTime;
				_delta = DateTime.Now.ToUniversalTime() - _serverTime;
			}
		}

		// TODO mb convert to device timezone. Shouldnt be hard, but only for entry time and not chests
		public bool TryGetCurrentTime(out DateTime time)
		{
			if (_delta == default)
			{
				time = default;
				return false;
			}

			time = DateTime.Now.Subtract(_delta);
			return true;
		}
		
		private async UniTask<(bool successful, DateTime serverTime)> TryGetServerTimeAsync()
		{
			var request = UnityWebRequest.Get(SERVER_PATH);
			await request.SendWebRequest();
			for (int i = 0; i < _numberOfConnectionRetries; i++)
			{
				if (request.result == UnityWebRequest.Result.Success)
				{
					var dateJson = request.downloadHandler.text;
					var date = JsonConvert.DeserializeObject<ServerTimeData>(dateJson);
					return (true, DateTime.Parse(date.dateTime));
				}
			}

			return (false, default);
		}

		private void OnApplicationFocus(bool focused)
		{
			// User may have tried to change system settings
			if (!focused) return;
			
				var serverTimeRequest = await TryGetServerTimeAsync();
				if (serverTimeRequest.successful)
				{
					_serverTime = serverTimeRequest.serverTime;
					_delta = DateTime.Now.ToUniversalTime() - _serverTime;
				}
				else
				{
					_serverTime = default;
					_delta = default;
				}					
		}

		private struct ServerTimeData
		{
			public string dateTime;
		}
	}
}