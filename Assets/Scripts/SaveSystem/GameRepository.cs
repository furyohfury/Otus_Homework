using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using ModestTree;
using Newtonsoft.Json;
using UnityEngine;

namespace Lessons.Architecture.SaveLoad
{
    public sealed class GameRepository : IGameRepository
    {
        private const string GAME_STATE_KEY = "Lesson/GameState";
        private const string SAVE_FILE_NAME = "SaveFile.txt";
        private string FullSaveFilePath => string.Concat(Application.persistentDataPath, "\\", SAVE_FILE_NAME);
        private Dictionary<string, string> _gameState = new();

        public void LoadState()
        {
            if (File.Exists(FullSaveFilePath))
            {
                var cryptedState = File.ReadAllText(FullSaveFilePath).Split(" ");
                var bytedState = cryptedState.Select(b =>
                {
                    if (byte.TryParse(b, out byte d))
                    {
                        return d;
                    }
                    else
                    {
                        Debug.Log($"Cant parse {b}, its index is {cryptedState.IndexOf(b)}");
                        return default;
                    }
                }).ToArray();

                var decryptedState = Cryptor.DecryptStringFromBytes(bytedState.ToArray());
                this._gameState = JsonConvert.DeserializeObject<Dictionary<string, string>>(decryptedState);
            }
            else
            {
                this._gameState = new Dictionary<string, string>();
            }
        }

        public void SaveState()
        {
            var serializedState = JsonConvert.SerializeObject(this._gameState, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });

            var cryptedState = new StringBuilder();
            var bytedState = Cryptor.EncryptStringToBytes(serializedState);
            for (int i = 0; i < bytedState.Length - 1; i++)
            {
                cryptedState.Append(bytedState[i] + " ");
            }
            cryptedState.Append(bytedState.Last());

            File.WriteAllText(FullSaveFilePath, cryptedState.ToString().TrimEnd());
        }

        public T GetData<T>()
        {
            var serializedData = this._gameState[typeof(T).FullName];
            return JsonConvert.DeserializeObject<T>(serializedData);
        }

        public bool TryGetData<T>(out T value)
        {
            if (this._gameState.TryGetValue(typeof(T).FullName, out var serializedData))
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
            this._gameState[typeof(T).FullName] = serializedData;
        }
    }
}