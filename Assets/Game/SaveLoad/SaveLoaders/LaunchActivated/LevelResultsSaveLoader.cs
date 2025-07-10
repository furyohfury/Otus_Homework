using System;
using System.Collections.Generic;
using Game;
using UnityEngine;

namespace SaveLoad
{
	public sealed class LevelResultsSaveLoader : SaveLoader<LevelData[], LevelsDataService>
	{
		protected override LevelData[] ConvertToData(LevelsDataService service)
		{
			var names = service.GetLevelNames();
			var savedData = new LevelData[names.Length];

			for (int i = 0, length = names.Length; i < length; i++)
			{
				if (service.TryGetLevelResults(names[i], out List<TimeSpan> results))
				{
					savedData[i] = new LevelData(names[i], results);
				}
				else
				{
					savedData[i] = new LevelData(names[i]);
				}
			}

			return savedData;
		}

		protected override void SetupData(LevelsDataService service, LevelData[] data)
		{
			for (int i = 0, length = data.Length; i < length; i++)
			{
				if (data[i].Results != null)
				{
					service.SetResult(data[i].Name, data[i].Results);
				}
			}
		}

		protected override void SetupByDefault(LevelsDataService service)
		{
			Debug.Log("No level results data was found. New one will be created");
		}
	}
}