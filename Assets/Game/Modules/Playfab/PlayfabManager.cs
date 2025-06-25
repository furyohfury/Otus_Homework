using System.Collections.Generic;
using System.Net.NetworkInformation;
using Cysharp.Threading.Tasks;
using PlayFab;
using PlayFab.ProgressionModels;
using UnityEngine;
using StatisticUpdate = PlayFab.ProgressionModels.StatisticUpdate;

namespace PlayFabSystem
{
	public static class PlayfabManager
	{
		public static string PlayerName;
		public static bool IsLogged;
		public static bool AttemptedLogin;

		public static async UniTask Login(string username)
		{
			try
			{
				await PlayfabLogger.LoginWithUsername(username);
				await PlayfabDisplayNameChanger.ChangeDisplayName(username);
				PlayerName = username;
				IsLogged = true;
			}
			finally
			{
				AttemptedLogin = true;
			}
		}

		public static UniTask<List<EntityLeaderboardEntry>> GetLeaderboard(string sceneName)
		{
			return PlayfabLeaderboardSystem.GetGlobalLeaderboard(sceneName);
		}

		private static void SetScoreToGothicChurch(string statName, int time)
		{
			PlayFabProgressionAPI.UpdateStatistics(
				new UpdateStatisticsRequest()
				{
					Statistics = new List<StatisticUpdate>()
					             {
						             new()
						             {
							             Scores = new List<string>()
							                      {
								                      time.ToString()
							                      }
							             , Name = statName
						             }
					             }
				},
				OnStatisticsUpdated,
				OnError
			);
		}

		private static void OnStatisticsUpdated(UpdateStatisticsResponse updateStatisticsResponse)
		{
			Debug.Log("Статистика успешно обновлена!");
		}

		private static void OnError(PlayFabError error)
		{
			Debug.LogError("Ошибка при обновлении статистики: " + error.GenerateErrorReport());
		}
	}
}