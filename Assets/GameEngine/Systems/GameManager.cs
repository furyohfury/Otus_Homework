using System;
using Cysharp.Threading.Tasks;
using UnityEditor;

namespace GameEngine
{
    public class GameManager
    {
        public void GameOver()
        {
            Pause().Forget();
        }

        private async UniTask Pause()
        {
            await UniTask.Delay(TimeSpan.FromSeconds(5));
            EditorApplication.isPaused = true;
        }
    }
}