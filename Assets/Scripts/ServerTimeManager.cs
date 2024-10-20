using System;
using System.Net;
using Cysharp.Threading.Tasks;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;

namespace RealTime
{
	public static class ServerTimeManager
	{
		private const string SERVER_PATH = "https://timeapi.io/api/time/current/zone?timeZone=Europe%2FMoscow";
		private static string _userIP;
		private static readonly int _numberOfConnectionRetries = 3;

		private static void GetUserIP()
		{
			try
			{
				var hostName = Dns.GetHostName();
				_userIP = Dns.GetHostEntry(hostName).AddressList[0].ToString();
			}
			catch (Exception e)
			{
				Debug.LogError("Cant get IP");
				_userIP = string.Empty;
			}
		}

		public static async UniTask<(bool successful, DateTime serverTime)> TryGetServerTimeAsync()
		{
			var request = UnityWebRequest.Get($"https://timeapi.io/api/time/current/zone?timeZone=Europe%2FMoscow");
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

		private struct ServerTimeData
		{
			public string dateTime;
		}
	}
}