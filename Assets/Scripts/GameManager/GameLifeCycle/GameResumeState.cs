using System.Collections.Generic;
using System.Linq;

namespace ShootEmUp
{
    public class GameResumeState : IGameState
    {
        public bool ActiveUpdates {get; } = true;
        
        public void HandleState(IEnumerable<IGameStateListener> listeners)
        {
            var resumeGameListeners = listeners.Where((l) => l is IGameResumeListener).Select((l) => l as IGameResumeListener).ToArray();
            foreach (var listener in resumeGameListeners)
            {
                listener.ResumeGame();
            }
        }
    }
}