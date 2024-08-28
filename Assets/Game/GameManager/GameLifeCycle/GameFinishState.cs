using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GameLifeCycle
{
    public class GameFinishState : IGameState
    {
        public bool ActiveUpdates { get; } = false;

        public void HandleState(IEnumerable<IGameStateListener> listeners)
        {
            var finishGameListeners = listeners.OfType<IGameFinishListener>();

            foreach (var listener in finishGameListeners)
            {
                listener.FinishGame();
            }
            Debug.Log("Game over");
        }
    }
}