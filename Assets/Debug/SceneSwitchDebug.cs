using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace GameDebug
{
	public class SceneSwitchDebug : MonoBehaviour
	{
		private bool _switched;

		private void Awake()
		{
			Debug.LogError("Show console in build");
			Debug.Log("SceneSwitchDebug Awake");
			SceneManager.sceneLoaded += OnSceneLoaded;
			DontDestroyOnLoad(gameObject);
		}

		private void Update()
		{
			if (_switched == false && Keyboard.current.jKey.wasPressedThisFrame)
			{
				StartCoroutine(LoadScene());
			}
			
			if (_switched == false && Keyboard.current.hKey.wasPressedThisFrame)
			{
				StartCoroutine(LoadSceneSingle());
			}
		}

		private IEnumerator LoadScene()
		{
			_switched = true;
			var load = SceneManager.LoadSceneAsync("GothicChurch", LoadSceneMode.Additive);
			while (load?.isDone == false)
			{
				yield return null;
			}
			var sceneByName = SceneManager.GetSceneByName("GothicChurch");
			SceneManager.SetActiveScene(sceneByName);
		}
		
		private IEnumerator LoadSceneSingle()
		{
			// Выгружаем неиспользуемые ресурсы
			AsyncOperation unloadOp = Resources.UnloadUnusedAssets();
			while (!unloadOp.isDone) yield return null;

			// Загружаем новую сцену
			AsyncOperation loadOp = SceneManager.LoadSceneAsync("GothicChurch", LoadSceneMode.Single);
			if (loadOp != null)
			{
				loadOp.allowSceneActivation = true;

				while (!loadOp.isDone) yield return null;
			}

			// Принудительная активация
			SceneManager.SetActiveScene(SceneManager.GetSceneByName("GothicChurch"));
		}

		private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
		{
			Debug.Log($"[SceneLoaded] Имя сцены: {scene.name}, LoadSceneMode: {mode}");
			// Посмотрим активные камеры
			foreach (var cam in Camera.allCameras)
			{
				Debug.Log($"Camera: {cam.name}, enabled={cam.enabled}, depth={cam.depth}, cullingMask={cam.cullingMask}");
			}
			// Посмотрим существующие EventSystem
			var eventSystems = FindObjectsOfType<UnityEngine.EventSystems.EventSystem>();
			Debug.Log($"Найдено EventSystem: {eventSystems.Length}");
		}

		void OnDestroy()
		{
			SceneManager.sceneLoaded -= OnSceneLoaded;
		}
	}
}