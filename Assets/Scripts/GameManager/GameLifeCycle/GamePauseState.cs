using System.Collections.Generic;
using System.Linq;

namespace ShootEmUp
{
    public class GamePauseState : IGameState
    {
        public bool ActiveUpdates {get; } = false;

        public void HandleState(IEnumerable<IGameStateListener> listeners)
        {
            var pauseGameListeners = listeners.
            Where((l) => l is IGamePauseListener).
            Select((l) => l as IGamePauseListener).
            ToArray();
            
            foreach (var listener in pauseGameListeners)
            {
                listener.PauseGame();
            }
        }
    }
}