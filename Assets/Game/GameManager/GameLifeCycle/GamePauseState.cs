using System.Collections.Generic;
using System.Linq;

namespace GameLifeCycle
{
    public class GamePauseState : IGameState
    {
        public bool ActiveUpdates { get; } = false;

        public void HandleState(IEnumerable<IGameStateListener> listeners)
        {
            var pauseGameListeners = listeners.OfType<IGamePauseListener>();

            foreach (var listener in pauseGameListeners)
            {
                listener.PauseGame();
            }
        }
    }
}