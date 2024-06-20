using System.Collections.Generic;
using System.Linq;
namespace ShootEmUp
{
    public class GameStartState : IGameState
    {
        public bool ActiveUpdates {get; } = true;
        
        public void HandleState(IEnumerable<IGameStateListener> listeners)
        {
            var startGameListeners = listeners.Where((l) => l is IGameStartListener).Select((l) => l as IGameStartListener).ToArray();
            foreach (var listener in startGameListeners)
            {
                listener.StartGame();
            }
        }
    }
}