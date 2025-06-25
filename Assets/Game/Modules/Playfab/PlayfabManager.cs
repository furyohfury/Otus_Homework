using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using PlayFab;
using PlayFab.ProgressionModels;
using UnityEngine;
using StatisticUpdate = PlayFab.ProgressionModels.StatisticUpdate;

namespace PlayFabSystem
{
	public static class PlayfabManager
	{
		public static async UniTask Login(string username)
		{
			await PlayfabLogger.LoginWithUsername(username);

			await PlayfabDisplayNameChanger.ChangeDisplayName(username);
		}

		public static void GetLeaderboard()
		{
			//tODO
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