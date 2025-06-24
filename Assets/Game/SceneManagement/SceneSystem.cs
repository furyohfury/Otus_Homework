using Cysharp.Threading.Tasks;
using Game;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SceneControls
{
	public static class SceneSystem
	{
		private const string LOADING_SCREEN_SCENE_NAME = "LoadingScreen";

		public static async UniTask SwitchToScene(string sceneName)
		{
			await LoadScene(sceneName);
		}

		private static async UniTask LoadScene(string sceneName)
		{
			await LoadLoadingScreen();
			var meter = Object.FindAnyObjectByType<LoadingMeter>();
			meter.SetFillMeterRatio(0f);
			var handle = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
			while (handle?.isDone == false)
			{
				meter.SetFillMeterRatio(handle.progress);
				await UniTask.Yield();
			}
		}

		private static async UniTask LoadLoadingScreen()
		{
			var task = SceneManager.LoadSceneAsync(LOADING_SCREEN_SCENE_NAME, LoadSceneMode.Additive).ToUniTask();
			await task;
			var loadingScreenScene = SceneManager.GetSceneByName(LOADING_SCREEN_SCENE_NAME);
			SceneManager.SetActiveScene(loadingScreenScene);
		}
		
	}
}