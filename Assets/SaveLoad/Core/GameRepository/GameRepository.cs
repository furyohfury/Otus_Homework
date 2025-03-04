using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;
using Zenject;

namespace SaveLoad
{
	public sealed class GameRepository : IGameRepository, IInitializable
	{
		private const string SAVE_FILE_NAME = "SaveFile.txt";
		private static string SaveFilePath => string.Concat(Application.persistentDataPath, "/", SAVE_FILE_NAME);
		private Dictionary<string, string> _gameState = new();

		public void Initialize()
		{
			LoadState();
		}

		public void LoadState()
		{
			if (File.Exists(SaveFilePath))
			{
				var savedState = File.ReadAllText(SaveFilePath);
				_gameState = JsonConvert.DeserializeObject<Dictionary<string, string>>(savedState, new JsonSerializerSettings
				                                                                                   {
					                                                                                   ReferenceLoopHandling =
						                                                                                   ReferenceLoopHandling.Ignore
					                                                                                   , TypeNameHandling = TypeNameHandling.Objects
				                                                                                   });
			}
			else
			{
				_gameState = new Dictionary<string, string>();
			}
		}

		public void SaveState()
		{
			var serializedState = JsonConvert.SerializeObject(_gameState, new JsonSerializerSettings
			                                                              {
				                                                              ReferenceLoopHandling = ReferenceLoopHandling.Ignore
				                                                              , TypeNameHandling = TypeNameHandling.Objects
			                                                              });
			File.WriteAllText(SaveFilePath, serializedState);
		}

		public T GetData<T>()
		{
			var serializedData = _gameState[typeof(T).FullName];
			return JsonConvert.DeserializeObject<T>(serializedData, new JsonSerializerSettings
			                                                        {
				                                                        TypeNameHandling = TypeNameHandling.Objects
			                                                        });
		}

		public bool TryGetData<T>(out T value)
		{
			if (_gameState.TryGetValue(typeof(T).FullName!, out var serializedData))
			{
				value = JsonConvert.DeserializeObject<T>(serializedData, new JsonSerializerSettings
				                                                         {
					                                                         TypeNameHandling = TypeNameHandling.Objects
				                                                         });
				return true;
			}

			value = default;
			Debug.LogWarning($"Couldn't get data of {typeof(T).FullName} from save repository");
			return false;
		}

		public void SetData<T>(T value)
		{
			var serializedData = JsonConvert.SerializeObject(value, new JsonSerializerSettings
			                                                        {
				                                                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
				                                                        , TypeNameHandling = TypeNameHandling.Objects
			                                                        });
			_gameState[typeof(T).FullName!] = serializedData;
		}
	}
}