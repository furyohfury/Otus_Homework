using UnityEngine.SceneManagement;

namespace SceneManagement
{
	public static class SceneSystem
	{
		public static void SwitchToScene(string sceneName)
		{
			SceneManager.LoadScene(sceneName);
			// TODO loading screen
		}
	}
}