using System.Collections.Generic;
using System.Linq;

namespace ShootEmUp
{
    public class GameFinishState : IGameState
    {
        public bool ActiveUpdates {get; } = false;

        public void HandleState(IEnumerable<IGameStateListener> listeners)
        {
            var finishGameListeners = listeners.Where((l) => l is IGameFinishListener).Select((l) => l as IGameFinishListener).ToArray();
            foreach (var listener in finishGameListeners)
            {
                listener.FinishGame();
            }
        }
    }
}