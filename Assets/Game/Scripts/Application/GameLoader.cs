using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

namespace SampleGame
{
    public sealed class GameLoader
    {
        private SceneInstance _sceneInstance;

        //TODO: Сделать через Addressables
        public void UnloadGame()
        {
            Addressables.UnloadSceneAsync(_sceneInstance);
        }
        
        //TODO: Сделать через Addressables
        public void LoadGame()
        {
            AsyncOperationHandle<SceneInstance> handle = Addressables.LoadSceneAsync("Game");
            _sceneInstance = handle.Result;
        }
    }
}