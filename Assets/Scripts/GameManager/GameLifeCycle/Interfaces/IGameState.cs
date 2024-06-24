using System.Collections.Generic;
namespace ShootEmUp
{
    public interface IGameState
    {
        bool ActiveUpdates { get; }
        void HandleState(IEnumerable<IGameStateListener> listeners);
    }
}