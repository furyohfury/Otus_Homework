using System;
using System.Collections.Generic;
using Game;
using PlayFabSystem;

namespace SaveLoad
{
	public sealed class PlayfabLevelResultsSaveLoader : SaveLoader<IList<LevelData>, ILevelsDataService>
	{
		private readonly PlayfabLevelNames _playfabLevelNames;

		public PlayfabLevelResultsSaveLoader(PlayfabLevelNames playfabLevelNames)
		{
			_playfabLevelNames = playfabLevelNames;
		}

		protected override IList<LevelData> ConvertToData(ILevelsDataService service)
		{
			var names = service.GetLevelNames();
			var savedData = new List<LevelData>();

			for (int i = 0, length = names.Length; i < length; i++)
			{
				if (service.TryGetLevelResults(names[i], out List<TimeSpan> results))
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

		protected override async void SetupData(ILevelsDataService service, IList<LevelData> data)
		{
			for (int i = 0, length = data.Count; i < length; i++)
			{
				List<TimeSpan> savedResults = data[i].Results;
				if (savedResults == null)
				{
					savedResults = new List<TimeSpan>();
				}

				var playfabLevelName = _playfabLevelNames.PlayfabStatisticName[data[i].Name];
				try
				{
					TimeSpan serverResultForLevel = await PlayfabManager.GetResultForLevel(playfabLevelName);
					savedResults.Add(serverResultForLevel);
				}
				catch
				{
					// ignored
				}
				finally
				{
					service.SetResult(data[i].Name, savedResults);
				}
			}
		}

		protected override async void SetupByDefault(ILevelsDataService service)
		{
			var levelNames = service.GetLevelNames();
			for (int i = 0, length = levelNames.Length; i < length; i++)
			{
				var playfabLevelName = _playfabLevelNames.PlayfabStatisticName[levelNames[i]];
				var results = new List<TimeSpan>();
				try
				{
					TimeSpan serverResultForLevel = await PlayfabManager.GetResultForLevel(playfabLevelName);
					results.Add(serverResultForLevel);
				}
				catch
				{
					// ignored
				}
				finally
				{
					service.SetResult(levelNames[i], results);
				}
			}
		}
	}
}