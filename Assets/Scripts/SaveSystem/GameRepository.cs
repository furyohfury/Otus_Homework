using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

namespace Lessons.Architecture.SaveLoad
{
    public sealed class GameRepository : IGameRepository
    {
        private const string SAVE_FILE_NAME = "SaveFile.txt";
        private string SaveFilePath => string.Concat(Application.persistentDataPath, "/", SAVE_FILE_NAME);
        private Dictionary<string, string> _gameState = new();

        public void LoadState() //todo into separate class
        {
            if (File.Exists(SaveFilePath))
            {
                var cryptedState = File.ReadAllText(SaveFilePath);
                var bytedState = CryptingService.StringToByteArray(cryptedState);
                var decryptedState = CryptingService.DecryptStringFromBytes(bytedState);
                _gameState = JsonConvert.DeserializeObject<Dictionary<string, string>>(decryptedState);
            }
            else
            {
                _gameState = new Dictionary<string, string>();
            }
        }

        public void SaveState() //todo into separate class
        {
            var serializedState = JsonConvert.SerializeObject(_gameState, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });

            var bytedState = CryptingService.EncryptStringToBytes(serializedState);
            var cryptedState = CryptingService.ByteArrayToString(bytedState);

            File.WriteAllText(SaveFilePath, cryptedState);
        }

        public T GetData<T>()
        {
            var serializedData = _gameState[typeof(T).FullName];
            return JsonConvert.DeserializeObject<T>(serializedData);
        }

        public bool TryGetData<T>(out T value)
        {
            if (_gameState.TryGetValue(typeof(T).FullName, out var serializedData))
            {
                value = JsonConvert.DeserializeObject<T>(serializedData);
                return true;
            }

            value = default;
            return false;
        }

        public void SetData<T>(T value)
        {
            var serializedData = JsonConvert.SerializeObject(value, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            _gameState[typeof(T).FullName] = serializedData;
        }
    }
}