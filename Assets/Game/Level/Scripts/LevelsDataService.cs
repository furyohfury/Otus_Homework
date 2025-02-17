using System;
using System.Collections.Generic;
using System.Linq;

namespace Game
{
	public sealed class LevelData
	{
		public string Name;
		public List<TimeSpan> Results;

		public LevelData(string name, List<TimeSpan> results = null)
		{
			Name = name;
			Results = results;
		}
	}

	public sealed class LevelResultsSaveLoader : SaveLoader<ICollection<LevelData>, LevelsDataService>
	{
		protected override ICollection<LevelData> ConvertToData(LevelsDataService service)
		{
			var names = service.GetNames();
			var savedData = new List<LevelData>();
			
			for (int i = 0, length = names.Length; i < length; i++)
			{
				if (service.TryGetLevelResults(names[i], out var results))
				{
					savedData.Add(new LevelData(names[i], results));
				}
				else
				{
					savedData.Add(new LevelData(names[i]));
				}
			}

			return savedData;
		}

		protected override void SetupData(LevelsDataService service, ICollection<LevelData> data)
		{
			for(int i = 0, length = data.Length; i < length; i++)
			{
				if (data[i].Results != null)
				{
					service.SetResult(data[i].Name, data.Results);
				}				
			}
		}
	}

	public sealed class LevelsDataService
	{	
		//TODO ctor

		private LevelCupsTimesConfig[] _configs;
		private Dictionary<string, List<TimeSpan>> _results; // separate class for results?

		public void SetResult(string levelName, List<TimeSpan> results)
		{
			_results[levelName] = results;
		}

		public string[] GetNames()
		{
			return _configs
				.Select(config => config.LevelName)
				.ToArray();
		}
			
		public bool TryGetLevelTargetTimes(string levelName, out Dictionary<Cups, List<TimeSpan>> targetTimes)
		{
			var config = _configs.SingleOrDefault(config => config.LevelName == levelName);
			if (config == default)
			{
				throw new NullReferenceException($"No listed level with name: {levelName}");
			}

			if (config.TryHasTargetTimes(out targetTimes) == false)
			{
				targetTimes = default;
				return false;
			}

			return true;
		}
		
		public bool TryGetLevelResults(string levelName, out List<TimeSpan> levelResults)
		{
			if (_results.TryGetValue(levelName, levelResults) == false)
			{
				levelResults = default;
				return false;
			}

			return true;
		}
	}
}