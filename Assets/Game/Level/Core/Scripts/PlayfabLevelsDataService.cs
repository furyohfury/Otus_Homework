using System;
using System.Collections.Generic;
using System.Linq;
using PlayFabSystem;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Game
{
	public sealed class PlayfabLevelsDataService : ILevelsDataService
	{
		private readonly Dictionary<string, LevelConfig> _configs;
		private readonly Dictionary<string, List<TimeSpan>> _results = new();

		private readonly PlayfabLevelNames _playfabLevelNames;

		[Inject]
		public PlayfabLevelsDataService(LevelConfig[] configs, PlayfabLevelNames playfabLevelNames)
		{
			_playfabLevelNames = playfabLevelNames;
			_configs = configs.ToDictionary(
				config => config.LevelName,
				config => config);
		}

		public string[] GetLevelNames()
		{
			return _configs
			       .Keys
			       .ToArray();
		}

		public string GetSceneName(string levelName)
		{
			return _configs[levelName].SceneName;
		}

		public Sprite GetLevelIcon(string levelName)
		{
			return _configs[levelName].Icon;
		}

		public string GetCurrentLevel()
		{
			var currentScene = SceneManager.GetActiveScene().name;
			var currentLevel = _configs.Keys.SingleOrDefault(key => _configs[key].SceneName == currentScene);

			if (currentLevel == default)
			{
				throw new NullReferenceException("No config with current scene name");
			}

			return currentLevel;
		}

		public bool TryGetLevelTargetTimes(string levelName, out Dictionary<Cups, TimeSpan> targetTimes)
		{
			if (_configs.TryGetValue(levelName, out LevelConfig config) == false)
			{
				throw new NullReferenceException($"No listed level with name: {levelName}");
			}

			if (config.TryGetLevelTargetTimes(out targetTimes) == false)
			{
				targetTimes = default;
				return false;
			}

			return true;
		}

		public void SetResult(string levelName, List<TimeSpan> results)
		{
			_results[levelName] = results;
			var levelStatName = _playfabLevelNames.PlayfabStatisticName[levelName];

			var result = results
			             .OrderBy(result => result)
			             .FirstOrDefault(result => result != TimeSpan.Zero)
			             .Milliseconds;
			if (result != default)
			{
				PlayfabManager.SetScoreToLevel(levelStatName, result);
			}
		}

		public bool TryGetLevelResults(string levelName, out List<TimeSpan> levelResults)
		{
			return _results.TryGetValue(levelName, out levelResults);
		}
	}
}