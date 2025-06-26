using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;
using Zenject;

namespace SaveLoad
{
	public sealed class NonFileGameRepository : IGameRepository, IInitializable
	{
		public IReadOnlyDictionary<string, string> GameState => _gameState;
		private Dictionary<string, string> _gameState = new();

		public void Initialize()
		{
			_gameState = new Dictionary<string, string>();
		}

		public void LoadState()
		{
		}

		public void SaveState()
		{
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
			Debug.LogWarning($"Couldn't get data of {typeof(T).Name} from save repository");
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