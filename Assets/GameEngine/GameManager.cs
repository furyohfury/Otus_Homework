using UnityEditor;

namespace GameEngine
{
    public class GameManager
    {
        public void GameOver()
        {
            EditorApplication.isPaused = true; // todo redo
        }
    }
}