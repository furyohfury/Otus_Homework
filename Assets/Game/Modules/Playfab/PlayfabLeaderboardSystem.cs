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
		private static readonly Dictionary<string, UniTask<TimeSpan>> _runningGetResultRequests = new();
		private static readonly Dictionary<string, UniTask> _runningSetResultRequests = new();
		
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

		public static UniTask SetScoreToLevel(string level, long time)
		{
			// Проверка: если запрос уже выполняется, вернуть его
			if (_runningSetResultRequests.TryGetValue(level, out var runningTask))
			{
				return runningTask;
			}
			
			var cts = new UniTaskCompletionSource();
			var task = cts.Task;
			_runningSetResultRequests[level] = task;
			
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
				response =>  OnStatisticsUpdated(response, level, time, cts),
				error => OnError(error, cts)
			);

			return task;
		}

		private static void OnStatisticsUpdated(UpdateStatisticsResponse updateStatisticsResponse, string level, long time
			, UniTaskCompletionSource cts)
		{
			var timeSpan = TimeSpan.FromTicks(time);
			Debug.Log($"Successfully set score of {timeSpan:g} to level {level}");
			cts.TrySetResult();
		}

		private static void OnError(PlayFabError error, UniTaskCompletionSource cts)
		{
			Debug.LogError("Couldnt update statistics. Error: " + error.GenerateErrorReport());
			cts.TrySetException(new Exception());
		}

		public static UniTask<TimeSpan> GetResultsForLevel(string level)
		{
			// Проверка: если запрос уже выполняется, вернуть его
			if (_runningGetResultRequests.TryGetValue(level, out var runningTask))
			{
				return runningTask;
			}
			
			var cts = new UniTaskCompletionSource<TimeSpan>();
			var task = cts.Task;
			_runningGetResultRequests[level] = task;
			
			PlayFabProgressionAPI.GetStatistics(
				new GetStatisticsRequest()
				{
					StatisticNames = new List<string>()
					                 {
						                 level
					                 }
				},
				response =>
				{
					OnGotResult(response, level, cts);
					RemoveRunningRequest(level);
				},
				error =>
				{
					OnErrorResult(error, cts);
					RemoveRunningRequest(level);
				});

			return task;
		}

		private static void OnGotResult(GetStatisticsResponse response,string level, UniTaskCompletionSource<TimeSpan> cts)
		{
			if (response.Statistics.TryGetValue(level, out EntityStatisticValue statisticValue) == false)
			{
				cts.TrySetException(new Exception($"No data for level {level}"));
				return;
			}
			if (!int.TryParse(statisticValue.Scores[0], out var result))
			{
				cts.TrySetException(new Exception("Invalid statistic value format."));
				return;
			}
			cts.TrySetResult(TimeSpan.FromTicks(result));
		}

		private static void OnErrorResult(PlayFabError error, UniTaskCompletionSource<TimeSpan> cts)
		{
			Debug.LogError(error.GenerateErrorReport());
			cts.TrySetException(new Exception("Cant get result for level"));
		}

		private static void RemoveRunningRequest(string level)
		{
			_runningGetResultRequests.Remove(level);
		}
	}
}