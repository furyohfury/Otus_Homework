using System;
using Cysharp.Threading.Tasks;
using Newtonsoft.Json;
using UnityEngine.Networking;

namespace RealTime
{
	public static class ServerTimeManager
	{
		private const string SERVER_PATH = "https://timeapi.io/api/time/current/zone?timeZone=Europe%2FMoscow";

		public static async UniTask<DateTime> GetServerTimeOrDefault()
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