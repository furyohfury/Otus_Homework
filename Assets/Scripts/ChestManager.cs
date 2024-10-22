using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using UnityEngine;
using Zenject;

namespace RealTime
{
	public sealed class ChestManager : MonoBehaviour
	{
		[SerializeField]
		private Transform[] _chestPositions;
		[SerializeField]
		private Transform _parentTransform;
		[SerializeField]
		private Chest[] _defaultChests;
		
		private string _saveFilePath;
		private ChestSpawner _chestSpawner;

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
				
			}
			else
			{
				CreateDefaultChests();
			}
		}

		private void CreateDefaultChests()
		{
			for (int i = 0; i < _defaultChests.Length; i++)
			{
				var chest = _chestSpawner.SpawnChest(_defaultChests[i], _chestPositions[i].position, _parentTransform);
			}
		}
	}
}