using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using PlayFab.ProgressionModels;

namespace PlayFabSystem
{
	public static class PlayfabManager
	{
		public static event Action OnLogged; 
		
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
				OnLogged?.Invoke();
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

		// public static void SetScoreToLevel(string level, int time)
		// {
		// 	PlayfabLeaderboardSystem.SetScoreToLevel(level, time);
		// }
		
		public static void SetScoreToLevel(string level, TimeSpan time)
		{
			PlayfabLeaderboardSystem.SetScoreToLevel(level, time.Ticks);
		}

		public static UniTask<TimeSpan> GetResultForLevel(string level)
		{
			return PlayfabLeaderboardSystem.GetResultsForLevel(level);
		}
	}
}