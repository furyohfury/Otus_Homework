using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using Cysharp.Threading.Tasks;
using PlayFab;
using PlayFab.ProgressionModels;
using UnityEngine;

namespace PlayFabSystem
{
	internal static class PlayfabLeaderboardSystem
	{
		public static UniTask<List<EntityLeaderboardEntry>> GetGlobalLeaderboard(string sceneName)
		{
			var cts = new UniTaskCompletionSource<List<EntityLeaderboardEntry>>();
			PlayFabProgressionAPI.GetLeaderboard(
				new GetEntityLeaderboardRequest()
				{
					LeaderboardName = sceneName, PageSize = 100, StartingPosition = 1
				},
				response => OnGetLeaderboard(response, cts),
				error => OnError(error, cts)
			);

			return cts.Task;
		}

		private static void OnGetLeaderboard(GetEntityLeaderboardResponse response, UniTaskCompletionSource<List<EntityLeaderboardEntry>> cts)
		{
			List<EntityLeaderboardEntry> rankings = response.Rankings;
			cts.TrySetResult(rankings);
			// foreach (var ranking in rankings)
			// {
			// 	Debug.Log($"{ranking.Rank} : {ranking.DisplayName} : {ranking.Scores[0]}");
			// }
		}

		private static void OnError(PlayFabError error, UniTaskCompletionSource<List<EntityLeaderboardEntry>> cts)
		{
			Debug.LogError("Couldn't get leaderboard" + error.GenerateErrorReport());
			cts.TrySetException(new NetworkInformationException());
		}

		public static void SetScoreToLevel(string level, int time)
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
							             , Name = level
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

		public static UniTask<TimeSpan> GetResultsForLevel(string level)
		{
			var cts = new UniTaskCompletionSource<TimeSpan>();
			PlayFabProgressionAPI.GetStatistics(
				new GetStatisticsRequest()
				{
					StatisticNames = new List<string>()
					                 {
						                 level
					                 }
				},
				response =>  OnGotResult(response,level, cts),
				error =>  OnErrorResult(error, cts)
				);

			return cts.Task;
		}

		private static void OnGotResult(GetStatisticsResponse response,string level, UniTaskCompletionSource<TimeSpan> cts)
		{
			if (!int.TryParse(response.Statistics[level].Scores[0], out var result))
			{
				cts.TrySetException(new Exception("Invalid statistic value format."));
				return;
			}
			cts.TrySetResult(TimeSpan.FromMilliseconds(result));
		}

		private static void OnErrorResult(PlayFabError error, UniTaskCompletionSource<TimeSpan> cts)
		{
			Debug.LogError(error.GenerateErrorReport());
			cts.TrySetException(new Exception("Cant get result for level"));
		}
	}
}