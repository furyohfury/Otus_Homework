using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

namespace SampleGame
{
    public sealed class MenuLoader
    {
        //TODO: Сделать через Addressables
        public void LoadMenu()
        {
            AsyncOperationHandle<SceneInstance> handle = Addressables.LoadSceneAsync("Menu");
        }
    }
}