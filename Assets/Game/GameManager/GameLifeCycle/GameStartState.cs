using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GameLifeCycle
{
    public class GameStartState : IGameState
    {
        public bool ActiveUpdates { get; } = false;

        public void HandleState(IEnumerable<IGameStateListener> listeners)
        {
            var startGameListeners = listeners.OfType<IGameStartListener>();

            foreach (var listener in startGameListeners)
            {
                listener.StartGame();
            }
        }
    }
}