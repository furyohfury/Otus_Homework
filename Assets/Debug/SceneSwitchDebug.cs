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
		}

		private void Update()
		{
			if (_switched == false && Keyboard.current.jKey.wasPressedThisFrame)
			{
				SceneManager.LoadScene("GothicChurch", LoadSceneMode.Single);
				// var sceneByName = SceneManager.GetSceneByName("GothicChurch");
				// SceneManager.SetActiveScene(sceneByName);
				// _switched = true;
			}
		}
	}
}