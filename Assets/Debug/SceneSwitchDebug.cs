using System.Collections;
using Cysharp.Threading.Tasks;
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
			SceneManager.sceneLoaded += OnSceneLoaded;
			DontDestroyOnLoad(gameObject);
		}

		private void Update()
		{
			if (_switched == false && Keyboard.current.jKey.wasPressedThisFrame)
			{
				_switched = true;
				StartCoroutine(LoadScene());
			}

			if (_switched == false && Keyboard.current.hKey.wasPressedThisFrame)
			{
				_switched = true;
				LoadSceneSingle();
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

		private void LoadSceneSingle()
		{
			SceneManager.LoadScene("GothicChurch", LoadSceneMode.Single);
		}

		private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
		{
			Debug.Log($"[SceneLoaded] Имя сцены: {scene.name}, LoadSceneMode: {mode}");
			// Посмотрим активные камеры
			// foreach (var cam in Camera.allCameras)
			// {
			// 	Debug.Log($"Camera: {cam.name}, enabled={cam.enabled}, depth={cam.depth}, cullingMask={cam.cullingMask}");
			// }
			// Посмотрим существующие EventSystem
			// var eventSystems = FindObjectsOfType<UnityEngine.EventSystems.EventSystem>();
			// Debug.Log($"Найдено EventSystem: {eventSystems.Length}");
		}

		private void OnDestroy()
		{
			SceneManager.sceneLoaded -= OnSceneLoaded;
		}
	}
}