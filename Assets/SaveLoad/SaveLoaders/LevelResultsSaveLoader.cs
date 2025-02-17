using System.Collections.Generic;
using Game;

namespace SaveLoad
{
	public sealed class LevelResultsSaveLoader : SaveLoader<IList<LevelData>, LevelsDataService>
	{
		protected override IList<LevelData> ConvertToData(LevelsDataService service)
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

		protected override void SetupData(LevelsDataService service, IList<LevelData> data)
		{
			for(int i = 0, length = data.Count; i < length; i++)
			{
				if (data[i].Results != null)
				{
					service.SetResult(data[i].Name, data[i].Results);
				}				
			}
		}
	}
}