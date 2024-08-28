using System.Collections.Generic;
namespace GameLifeCycle
{
    public interface IGameState
    {
        bool ActiveUpdates { get; }
        void HandleState(IEnumerable<IGameStateListener> listeners);
    }
}