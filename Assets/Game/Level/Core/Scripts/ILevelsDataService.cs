using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
	public interface ILevelsDataService
	{
		string[] GetLevelNames();
		string GetSceneName(string levelName);
		Sprite GetLevelIcon(string levelName);
		string GetCurrentLevel();
		void SetResult(string levelName, List<TimeSpan> results);
		bool TryGetLevelTargetTimes(string levelName, out Dictionary<Cups, TimeSpan> targetTimes);
		bool TryGetLevelResults(string levelName, out List<TimeSpan> levelResults);
	}
}