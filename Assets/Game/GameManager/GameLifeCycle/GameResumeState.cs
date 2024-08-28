using System.Collections.Generic;
using System.Linq;

namespace GameLifeCycle
{
    public class GameResumeState : IGameState
    {
        public bool ActiveUpdates { get; } = true;

        public void HandleState(IEnumerable<IGameStateListener> listeners)
        {
            var resumeGameListeners = listeners.OfType<IGameResumeListener>();

            foreach (var listener in resumeGameListeners)
            {
                listener.ResumeGame();
            }
        }
    }
}