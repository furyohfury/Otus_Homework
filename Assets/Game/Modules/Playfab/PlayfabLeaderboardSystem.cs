using System.Collections.Generic;
using PlayFab;
using PlayFab.ProgressionModels;
using UnityEngine;

namespace PlayFabSystem
{
	internal static class PlayfabLeaderboardSystem
	{
		public static void PrintLeaderboard()
		{
			PlayFabProgressionAPI.GetLeaderboard(
				new GetEntityLeaderboardRequest()
				{
					LeaderboardName = "GothicChurch", PageSize = 100, StartingPosition = 1
				},
				OnGetLeaderboard,
				error => Debug.LogError("Couldn't get leaderboard" + error.GenerateErrorReport())
			);
		}

		private static void OnGetLeaderboard(GetEntityLeaderboardResponse response)
		{
			List<EntityLeaderboardEntry> rankings = response.Rankings;
			foreach (var ranking in rankings)
			{
				Debug.Log($"{ranking.Rank} : {ranking.DisplayName} : {ranking.Scores[0]}");
			}
		}
	}
}