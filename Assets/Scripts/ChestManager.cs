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
		private IChestSaveLoader _chestSaveLoader;
		private List<Chest> _activeChests = new();

		[Inject]
		public void Construct(ChestSpawner chestSpawner, IChestSaveLoader chestSaveLoader)
		{
			_chestSpawner = chestSpawner;
			_chestSaveLoader = chestSaveLoader;
		}

		private void Start()
		{			
			_chestPositions = _chestPositions.OrderBy(pos => pos.position.x).ThenBy(pos => pos.position.y).ToArray();

			if (_chestSaveLoader.TryLoadChestsData(out IEnumerable<ChestData> data))
			{
				var savedChestData = data.ToArray();
				for (int i = 0; i < savedChestData.Length; i++)
				{
					var chest = _chestSpawner.SpawnChest(savedChestData[i], _chestPositions[i].position, _parentTransform);
					_activeChests.Add(chest);
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
				_activeChests.Add(chest);
			}
		}
		
		private void OnApplicationQuit()
		{
			_chestSaveLoader.SaveChestsData(_activeChests);
		}
	}
}