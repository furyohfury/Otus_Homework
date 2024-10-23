using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using UnityEngine;
using Zenject;

namespace RealTime
{
	public sealed class ChestManager : MonoBehaviour // TODO can change with DI and IDisposable
	{
		[SerializeField]
		private Transform[] _chestPositions;
		[SerializeField]
		private Transform _parentTransform;
		[SerializeField]
		private Chest[] _defaultChests;
		
		
		private string _saveFilePath;
		private ChestSpawner _chestSpawner;
		private List<Chest> _activeChests = new();

		[Inject]
		public void Construct(ChestSpawner chestSpawner)
		{
			_chestSpawner = chestSpawner;
		}

		private void Start()
		{
			_saveFilePath = Path.Combine(Application.persistentDataPath, "ChestData.json");
			_chestPositions = _chestPositions.OrderBy(pos => pos.position.x).ThenBy(pos => pos.position.y).ToArray();

			if (File.Exists(_saveFilePath))
			{
				var fileData = File.ReadAllText(_saveFilePath);
				List<Chest> savedChests = JsonConvert.DeserializeObject<List<Chest>>(fileData);
				for (int i = 0; i < savedChests.Length; i++)
				{
					var chest = _chestSpawner.SpawnFromPrefab(savedChests[i], _chestPositions[i].position, _parentTransform);
					_chests.Add(chest);
				}
			}
			else
			{
				Debug.LogWarning("No saved chests. Creating default ones");
				CreateDefaultChests();
			}
		}

		private void CreateDefaultChests()
		{
			for (int i = 0; i < _defaultChests.Length; i++)
			{
				var chest = _chestSpawner.SpawnChest(_defaultChests[i], _chestPositions[i].position, _parentTransform);
				_chests.Add(chest);
			}
		}		

		// TODO mb with separate saveloader and interface. So would be able to download from server, file etc
		private void SaveChestsData() 
		{
			var serializedChests = JsonConvert.SerializeObject(_chests);
			File.WriteAllText(_saveFilePath, serializedChests);
		}

		private void OnApplicationQuit()
		{
			SaveChestsData();
		}
	}
}