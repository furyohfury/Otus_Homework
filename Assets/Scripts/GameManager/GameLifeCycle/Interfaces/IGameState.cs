using System.Collections.Generic;
namespace ShootEmUp
{
    public interface IGameState
    {
        void HandleState(IEnumerable<IGameStateListener> listeners);
    }
}