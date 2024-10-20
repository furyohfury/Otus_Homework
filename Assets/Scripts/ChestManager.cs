using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

namespace RealTime
{
	public sealed class ChestManager : MonoBehaviour
	{
		private Chest[] _chests;
		private const string CHEST_DATA_KEY = nameof(CHEST_DATA_KEY);

		private void Start()
		{
			_chests = FindObjectsOfType<Chest>();

			if (PlayerPrefs.HasKey(CHEST_DATA_KEY))
			{
				var chestData = PlayerPrefs.GetString(CHEST_DATA_KEY);
				var savedData = JsonConvert.DeserializeObject<Dictionary<Chest, int>>(chestData);
			}
			
			foreach (var chest in savedData.Keys)
			{
				chest.Initialize(savedData[chest]);
			}
		}

		private void OnApplicationPause(bool pauseStatus)
		{
			if (pauseStatus != true) return;
			
			var durationsDictionary = new Dictionary<Chest, int>();
			foreach (var chest in _chests)
			{
				durationsDictionary.Add(chest, (int) chest.TimeLeft.TotalSeconds);
			}

			var savedDurations = JsonConvert.SerializeObject(durationsDictionary);
			PlayerPrefs.SetString(CHEST_DATA_KEY, savedDurations);
		}
	}
}