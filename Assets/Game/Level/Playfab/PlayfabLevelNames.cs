using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game
{
	[CreateAssetMenu(fileName = "PlayfabLevelNames", menuName = "Create config/Playfab/PlayfabLevelNames")]
	public sealed class PlayfabLevelNames : SerializedScriptableObject
	{
		public IReadOnlyDictionary<string, string> PlayfabStatisticName => _playfabStatisticName;
		public IReadOnlyDictionary<string, string> PlayfabLeaderboardName => _playfabStatisticName;
		
		[SerializeField]
		private Dictionary<string, string> _playfabStatisticName;
		[SerializeField]
		private Dictionary<string, string> _playfabLeaderboardName;

		[Button]
		private void FillFromConfig(LevelConfig levelConfig, string statname, string leaderboardname)
		{
			_playfabStatisticName.TryAdd(levelConfig.LevelName, statname);
			_playfabLeaderboardName.TryAdd(levelConfig.LevelName, leaderboardname);
		}
	}
}