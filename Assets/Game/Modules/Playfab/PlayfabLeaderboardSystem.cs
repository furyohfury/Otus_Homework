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
	}
}