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

		static ServerTimeManager()
		{
			GetUserIP();
		}

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
		
		public static async UniTask<DateTime> GetServerTimeByIPAsync()
		{
			if (_userIP == string.Empty)
			{
				GetUserIP();
				if (_userIP == string.Empty)
				{
					throw new Exception("Cant get IP");
				}
			}
			
			var request = UnityWebRequest.Get($"https://timeapi.io/api/time/current/ip?ipAddress={_userIP}");
			await request.SendWebRequest();
			if (request.result == UnityWebRequest.Result.Success)
			{
				var dateJson = request.downloadHandler.text;
				var date = JsonConvert.DeserializeObject<ServerTimeData>(dateJson);
				return DateTime.Parse(date.dateTime);
			}

			throw new Exception("Cant get time from server");
		}

		private struct ServerTimeData
		{
			public string dateTime;
		}
	}
}