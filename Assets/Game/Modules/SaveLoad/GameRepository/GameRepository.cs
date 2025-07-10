using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

namespace SaveLoad
{
	public sealed class GameRepository : IGameRepository
	{
		public IReadOnlyDictionary<string, string> GameState => _gameState;

		private const string SAVE_FILE_NAME = "savefile.json";
		private static string SaveFilePath => Path.Combine(Application.persistentDataPath, SAVE_FILE_NAME);
		private Dictionary<string, string> _gameState = new();

		public void LoadState()
		{
			if (File.Exists(SaveFilePath))
			{
				var savedState = File.ReadAllText(SaveFilePath);
				try
				{
					_gameState = JsonConvert.DeserializeObject<Dictionary<string, string>>(savedState, new JsonSerializerSettings
						{
							ReferenceLoopHandling =
								ReferenceLoopHandling.Ignore
							, TypeNameHandling = TypeNameHandling.Objects
						});
				}
				catch (Exception e)
				{
					Debug.LogError($"Deserialize error in LoadState().\nStack trace:{e.StackTrace}");
				}
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
			var serializedData = _gameState[typeof(T).FullName!];
			try
			{
				return JsonConvert.DeserializeObject<T>(serializedData, new JsonSerializerSettings
				                                                        {
					                                                        TypeNameHandling = TypeNameHandling.Objects
				                                                        });
			}
			catch (Exception e)
			{
				Debug.LogError($"Deserialize error in GetData() of type {typeof(T).FullName}.\nStack trace:{e.StackTrace}");
				throw;
			}
		}

		public bool TryGetData<T>(out T value)
		{
			if (_gameState.TryGetValue(typeof(T).FullName!, out var serializedData))
			{
				try
				{
					value = JsonConvert.DeserializeObject<T>(serializedData, new JsonSerializerSettings
					                                                         {
						                                                         TypeNameHandling = TypeNameHandling.Objects
					                                                         });
					return true;
				}
				catch (Exception e)
				{
					Debug.LogError($"Deserialize error in TryGetData() of type {typeof(T).FullName}.\nStack trace:{e.StackTrace}");
					throw;
				}
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