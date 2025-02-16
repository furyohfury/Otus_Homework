using System;
using System.Collections.Generic;
using System.Linq;

namespace Game
{
	public sealed class LevelsDataService // TODO saveloader for this
	{
		private LevelCupsTimesConfig[] _configs;
		private Dictionary<string, List<TimeSpan>> _results;
			
		public Dictionary<Cups, List<TimeSpan>> GetLevelTargetTimes(string levelName)
		{
			var config = _configs.SingleOrDefault(config => config.LevelName == levelName);
			if (config == default)
			{
				
			}

			throw new NullReferenceException($"No saved results for {levelName}");
		}
		
		public List<TimeSpan> GetLevelResults(string levelName)
		{
			if (_results.TryGetValue(levelName, out List<TimeSpan> levelResults))
			{
				return levelResults;
			}

			throw new NullReferenceException($"No saved results for {levelName}");
		}
	}
}