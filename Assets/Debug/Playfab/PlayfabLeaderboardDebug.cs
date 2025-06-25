using System;
using PlayFabSystem;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GameDebug
{
	public class PlayfabLeaderboardDebug : MonoBehaviour
	{
		[Button]
		private async void Login(string user)
		{
			await PlayfabManager.Login(user);
		}
		
		[Button]
		private async void GetResult(string level)
		{
			TimeSpan resultForLevel = await PlayfabManager.GetResultForLevel(level);
			Debug.Log(resultForLevel.TotalMilliseconds.ToString());
		}
	}
}