using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Game
{
	public sealed class LevelsDataService
	{
		public string CurrentLevel => SceneManager.GetActiveScene().name; // TODO make some scenemanager having current level name?

		private readonly Dictionary<string, LevelConfig> _configs;
		private readonly Dictionary<string, List<TimeSpan>> _results = new(); // TODO mb separate class for results?

		[Inject]
		public LevelsDataService(LevelConfig[] configs)
		{
			_configs = configs.ToDictionary(
				config => config.LevelName,
				config => config);
		}

		public string[] GetNames()
		{
			return _configs
			       .Keys
			       .ToArray();
		}

		public Sprite GetLevelIcon(string levelName)
		{
			return _configs[levelName].Icon;
		}

		public void SetResult(string levelName, List<TimeSpan> results)
		{
			_results[levelName] = results;
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

		public bool TryGetLevelResults(string levelName, out List<TimeSpan> levelResults)
		{
			return _results.TryGetValue(levelName, out levelResults);
		}
	}
}