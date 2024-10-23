using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using UnityEngine;

namespace RealTime
{
	public sealed class FileChestSaveLoader : IChestSaveLoader
	{
		private readonly string _saveFilePath = Path.Combine(Application.persistentDataPath, "ChestData.json");

		public void SaveChestsData(IEnumerable<Chest> chests)
		{
			var data = chests.Select(chest => new ChestData(chest.Timer, chest.Rewards, chest.ChestType)).ToArray();

			var serializedChests = JsonConvert.SerializeObject(data);
			File.WriteAllText(_saveFilePath, serializedChests);
		}

		public bool TryLoadChestsData(out IEnumerable<ChestData> data)
		{
			if (!File.Exists(_saveFilePath))
			{
				data = null;
				return false;
			}

			var fileData = File.ReadAllText(_saveFilePath);
			
			var savedChests = JsonConvert.DeserializeObject<ChestData[]>(fileData);
			if (savedChests == null || savedChests.Length <= 0)
			{
				data = null;
				return false;
			}
			
			data = savedChests;
			return true;
		}
	}
}