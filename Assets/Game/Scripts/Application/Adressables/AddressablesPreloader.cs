using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace SampleGame
{
	public static class AddressablesPreloader
	{
		private const string PATH = "PreloadAssetsConfig";

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		public static async void PreloadEverything()
		{
			var preloadAssetsConfig = await Addressables.LoadAssetAsync<PreloadAssetsConfig>(PATH).Task;
			if (preloadAssetsConfig != null)
			{
				var taskList = new Task<Object>[preloadAssetsConfig.PreloadedAssets.Length];

				var assetReferences = preloadAssetsConfig.PreloadedAssets;
				for (int i = 0, count = assetReferences.Length; i < count; i++)
				{
					var handle = Addressables.LoadAssetAsync<Object>(assetReferences[i]);
					taskList[i] = handle.Task;
				}

				await Task.WhenAll(taskList);
				Debug.Log("Assets preloaded");
			}
		}
	}
}